using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFormationDebug.Model
{
    public class Validateurs
    {

        private static Validateurs _Courant = null;

        public static Validateurs Courant
        {
            get
            {
                if (_Courant == null)
                {
                    _Courant = new Validateurs();
                }
                return _Courant;
            }
        }

        private Dictionary<Type, Dictionary<string, List<ValidationAttribute>>> TypeValidator = new Dictionary<Type, Dictionary<string, List<ValidationAttribute>>>();

        public Dictionary<string, List<ValidationAttribute>> ReferencerType(Type T, Object O)
        {


            Dictionary<string, List<ValidationAttribute>> Validator = new Dictionary<string, List<ValidationAttribute>>();



            // recuperation des Attributs de Validation via les Metadata Type Attribute
            MetadataTypeAttribute[] MetadataTypeAttributes = (MetadataTypeAttribute[])T.GetCustomAttributes(typeof(MetadataTypeAttribute), true);

            // on ne traite que le cas ou il n'y en a qu'un a voir pour plusieurs
            MetadataTypeAttribute MdTa = MetadataTypeAttributes.FirstOrDefault();

            if ((MdTa != null) && (MdTa.MetadataClassType != null))
            {
                foreach (PropertyInfo PI in MdTa.MetadataClassType.GetProperties())
                {
                    List<ValidationAttribute> VA = GetValidations(PI);
                    if (VA.Count != 0)
                    {
                        Validator.Add(PI.Name, VA);
                    }
                }

            }


            // la valeur est requis peu etre recupéré depuis le Modele Entity
            //[EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)] 
            // en prenant la valeurs de IsNullable, qui rend le champs obligatoire ou non

            foreach (PropertyInfo PI in T.GetProperties())
            {

                // Modele Entity
                EdmScalarPropertyAttribute[] PA = (EdmScalarPropertyAttribute[])PI.GetCustomAttributes(typeof(EdmScalarPropertyAttribute), true);
                if (PA.Length != 0)
                {

                    if (!PA[0].IsNullable)
                    {
                        AjoutValidator_Obligatoire(Validator, PI);

                    }
                }

                // WievModel, ou object en general

                List<ValidationAttribute> VA = GetValidations(PI);
                if (VA.Count != 0)
                {
                    Validator.Add(PI.Name, VA);
                }


                /*
                EdmRelationshipNavigationPropertyAttribute[] NP = (EdmRelationshipNavigationPropertyAttribute[])PI.GetCustomAttributes(typeof(EdmRelationshipNavigationPropertyAttribute), true);
                if (NP.Length != 0)
                {
                    string RelationShipName = NP[0].RelationshipNamespaceName + "." + NP[0].RelationshipName;
                    string TargetRoleName = NP[0].TargetRoleName;

                    if (O is IEntityWithRelationships)
                    {
                        IEntityWithRelationships IEWR = (O as IEntityWithRelationships);

                        foreach (System.Data.Metadata.Edm.AssociationSet assoc in IEWR.RelationshipManager
                            .GetAllRelatedEnds().Select(end => end.RelationshipSet)
                            .Where(rs => rs is System.Data.Metadata.Edm.AssociationSet && ((System.Data.Metadata.Edm.AssociationSet)rs)
                                .ElementType.IsForeignKey).Cast<System.Data.Metadata.Edm.AssociationSet>())
                        {

                            AjoutValidator_Obligatoire(Validator, PI);
                        }
                    }
                }
                */
            }


            if (Validator != null)
            {
                TypeValidator.Add(T, Validator);
            }


            // enfin le Type peu etre un viewmodel type object



            return Validator;
        }

        private static void AjoutValidator_Obligatoire(Dictionary<string, List<ValidationAttribute>> Validator, PropertyInfo PI)
        {
            RequiredAttribute RA = new RequiredAttribute();
            RA.ErrorMessage = "Le champs " + PI.Name + " est obligatoire.";

            if (Validator.ContainsKey(PI.Name))
            {
                // inutile de remettre un autre RequiredAttribute
                if (Validator[PI.Name].FirstOrDefault(V => V.GetType() == typeof(RequiredAttribute)) == null)
                {
                    Validator[PI.Name].Add(RA);
                }
            }
            else
            {
                List<ValidationAttribute> LVA = new List<ValidationAttribute>();
                LVA.Add(RA);
                Validator.Add(PI.Name, LVA);

            }
        }

        public string GetErreurs(object O)
        {

            Type ObjectType = O.GetType();

            Dictionary<string, List<ValidationAttribute>> dicValidators = null;

            if (!TypeValidator.TryGetValue(ObjectType, out dicValidators))
            {
                dicValidators = ReferencerType(ObjectType, O);
            }


            var errors = from Validators in dicValidators
                         from Valid in Validators.Value

                         where
                         !Valid.IsValid(ObjectType.GetProperty(Validators.Key).GetValue(O, null))

                         select Valid.ErrorMessage;

            return string.Join(Environment.NewLine, errors.ToArray());

        }

        public string GetErreur(object O, string Property)
        {
            Type ObjectType = O.GetType();

            Dictionary<string, List<ValidationAttribute>> dicValidators = null;

            if (!TypeValidator.TryGetValue(ObjectType, out dicValidators))
            {
                dicValidators = ReferencerType(ObjectType, O);
            }

            if (dicValidators.ContainsKey(Property))
            {
                var value = ObjectType.GetProperty(Property).GetValue(O, null);
                var errors = dicValidators[Property].Where(v => !v.IsValid(value))
                    .Select(v => v.ErrorMessage).ToArray();
                return string.Join(Environment.NewLine, errors);
            }

            return string.Empty;
        }

        private static List<ValidationAttribute> GetValidations(PropertyInfo property)
        {
            return ((ValidationAttribute[])property.GetCustomAttributes(typeof(ValidationAttribute), true)).ToList();
        }

    }
}
