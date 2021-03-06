﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region Métadonnées de relation EDM

[assembly: EdmRelationshipAttribute("ProjetFormationDebugModel", "FK_CompetencePersonne", "Competences", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(ProjetFormationDebug.Model.Competence), "Personnes", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ProjetFormationDebug.Model.Personne), true)]
[assembly: EdmRelationshipAttribute("ProjetFormationDebugModel", "ProjetLot", "Projet", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(ProjetFormationDebug.Model.Projet), "Lot", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ProjetFormationDebug.Model.Lot))]

#endregion

namespace ProjetFormationDebug.Model
{
    #region Contextes
    
    /// <summary>
    /// Aucune documentation sur les métadonnées n'est disponible.
    /// </summary>
    public partial class ModelDebugEntities : ObjectContext
    {
        #region Constructeurs
    
        /// <summary>
        /// Initialise un nouvel objet ModelDebugEntities à l'aide de la chaîne de connexion trouvée dans la section 'ModelDebugEntities' du fichier de configuration d'application.
        /// </summary>
        public ModelDebugEntities() : base("name=ModelDebugEntities", "ModelDebugEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisez un nouvel objet ModelDebugEntities.
        /// </summary>
        public ModelDebugEntities(string connectionString) : base(connectionString, "ModelDebugEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisez un nouvel objet ModelDebugEntities.
        /// </summary>
        public ModelDebugEntities(EntityConnection connection) : base(connection, "ModelDebugEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Méthodes partielles
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Propriétés ObjectSet
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        public ObjectSet<Competence> Competences
        {
            get
            {
                if ((_Competences == null))
                {
                    _Competences = base.CreateObjectSet<Competence>("Competences");
                }
                return _Competences;
            }
        }
        private ObjectSet<Competence> _Competences;
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        public ObjectSet<Personne> Personnes
        {
            get
            {
                if ((_Personnes == null))
                {
                    _Personnes = base.CreateObjectSet<Personne>("Personnes");
                }
                return _Personnes;
            }
        }
        private ObjectSet<Personne> _Personnes;
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        public ObjectSet<Projet> Projets
        {
            get
            {
                if ((_Projets == null))
                {
                    _Projets = base.CreateObjectSet<Projet>("Projets");
                }
                return _Projets;
            }
        }
        private ObjectSet<Projet> _Projets;
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        public ObjectSet<Lot> Lots
        {
            get
            {
                if ((_Lots == null))
                {
                    _Lots = base.CreateObjectSet<Lot>("Lots");
                }
                return _Lots;
            }
        }
        private ObjectSet<Lot> _Lots;

        #endregion

        #region Méthodes AddTo
    
        /// <summary>
        /// Méthode déconseillée pour ajouter un nouvel objet à l'EntitySet Competences. Utilisez la méthode .Add de la propriété ObjectSet&lt;T&gt; associée à la place.
        /// </summary>
        public void AddToCompetences(Competence competence)
        {
            base.AddObject("Competences", competence);
        }
    
        /// <summary>
        /// Méthode déconseillée pour ajouter un nouvel objet à l'EntitySet Personnes. Utilisez la méthode .Add de la propriété ObjectSet&lt;T&gt; associée à la place.
        /// </summary>
        public void AddToPersonnes(Personne personne)
        {
            base.AddObject("Personnes", personne);
        }
    
        /// <summary>
        /// Méthode déconseillée pour ajouter un nouvel objet à l'EntitySet Projets. Utilisez la méthode .Add de la propriété ObjectSet&lt;T&gt; associée à la place.
        /// </summary>
        public void AddToProjets(Projet projet)
        {
            base.AddObject("Projets", projet);
        }
    
        /// <summary>
        /// Méthode déconseillée pour ajouter un nouvel objet à l'EntitySet Lots. Utilisez la méthode .Add de la propriété ObjectSet&lt;T&gt; associée à la place.
        /// </summary>
        public void AddToLots(Lot lot)
        {
            base.AddObject("Lots", lot);
        }

        #endregion

    }

    #endregion

    #region Entités
    
    /// <summary>
    /// Aucune documentation sur les métadonnées n'est disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ProjetFormationDebugModel", Name="Competence")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Competence : EntityObject
    {
        #region Méthode de fabrique
    
        /// <summary>
        /// Créez un nouvel objet Competence.
        /// </summary>
        /// <param name="id">Valeur initiale de la propriété Id.</param>
        /// <param name="libelle">Valeur initiale de la propriété Libelle.</param>
        /// <param name="libelleCourt">Valeur initiale de la propriété LibelleCourt.</param>
        /// <param name="couleur">Valeur initiale de la propriété Couleur.</param>
        public static Competence CreateCompetence(global::System.Int32 id, global::System.String libelle, global::System.String libelleCourt, global::System.String couleur)
        {
            Competence competence = new Competence();
            competence.Id = id;
            competence.Libelle = libelle;
            competence.LibelleCourt = libelleCourt;
            competence.Couleur = couleur;
            return competence;
        }

        #endregion

        #region Propriétés primitives
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Libelle
        {
            get
            {
                return _Libelle;
            }
            set
            {
                OnLibelleChanging(value);
                ReportPropertyChanging("Libelle");
                _Libelle = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Libelle");
                OnLibelleChanged();
            }
        }
        private global::System.String _Libelle;
        partial void OnLibelleChanging(global::System.String value);
        partial void OnLibelleChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LibelleCourt
        {
            get
            {
                return _LibelleCourt;
            }
            set
            {
                OnLibelleCourtChanging(value);
                ReportPropertyChanging("LibelleCourt");
                _LibelleCourt = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LibelleCourt");
                OnLibelleCourtChanged();
            }
        }
        private global::System.String _LibelleCourt;
        partial void OnLibelleCourtChanging(global::System.String value);
        partial void OnLibelleCourtChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Couleur
        {
            get
            {
                return _Couleur;
            }
            set
            {
                OnCouleurChanging(value);
                ReportPropertyChanging("Couleur");
                _Couleur = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Couleur");
                OnCouleurChanged();
            }
        }
        private global::System.String _Couleur;
        partial void OnCouleurChanging(global::System.String value);
        partial void OnCouleurChanged();

        #endregion

    
        #region Propriétés de navigation
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ProjetFormationDebugModel", "FK_CompetencePersonne", "Personnes")]
        public EntityCollection<Personne> Personnes
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Personne>("ProjetFormationDebugModel.FK_CompetencePersonne", "Personnes");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Personne>("ProjetFormationDebugModel.FK_CompetencePersonne", "Personnes", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// Aucune documentation sur les métadonnées n'est disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ProjetFormationDebugModel", Name="Lot")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Lot : EntityObject
    {
        #region Méthode de fabrique
    
        /// <summary>
        /// Créez un nouvel objet Lot.
        /// </summary>
        /// <param name="id">Valeur initiale de la propriété ID.</param>
        /// <param name="nom">Valeur initiale de la propriété Nom.</param>
        public static Lot CreateLot(global::System.Int32 id, global::System.String nom)
        {
            Lot lot = new Lot();
            lot.ID = id;
            lot.Nom = nom;
            return lot;
        }

        #endregion

        #region Propriétés primitives
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Nom
        {
            get
            {
                return _Nom;
            }
            set
            {
                OnNomChanging(value);
                ReportPropertyChanging("Nom");
                _Nom = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Nom");
                OnNomChanged();
            }
        }
        private global::System.String _Nom;
        partial void OnNomChanging(global::System.String value);
        partial void OnNomChanged();

        #endregion

    
        #region Propriétés de navigation
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ProjetFormationDebugModel", "ProjetLot", "Projet")]
        public Projet Projet
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Projet>("ProjetFormationDebugModel.ProjetLot", "Projet").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Projet>("ProjetFormationDebugModel.ProjetLot", "Projet").Value = value;
            }
        }
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Projet> ProjetReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Projet>("ProjetFormationDebugModel.ProjetLot", "Projet");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Projet>("ProjetFormationDebugModel.ProjetLot", "Projet", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// Aucune documentation sur les métadonnées n'est disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ProjetFormationDebugModel", Name="Personne")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Personne : EntityObject
    {
        #region Méthode de fabrique
    
        /// <summary>
        /// Créez un nouvel objet Personne.
        /// </summary>
        /// <param name="id">Valeur initiale de la propriété Id.</param>
        public static Personne CreatePersonne(global::System.Int32 id)
        {
            Personne personne = new Personne();
            personne.Id = id;
            return personne;
        }

        #endregion

        #region Propriétés primitives
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Nom
        {
            get
            {
                return _Nom;
            }
            set
            {
                OnNomChanging(value);
                ReportPropertyChanging("Nom");
                _Nom = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Nom");
                OnNomChanged();
            }
        }
        private global::System.String _Nom;
        partial void OnNomChanging(global::System.String value);
        partial void OnNomChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Prenom
        {
            get
            {
                return _Prenom;
            }
            set
            {
                OnPrenomChanging(value);
                ReportPropertyChanging("Prenom");
                _Prenom = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Prenom");
                OnPrenomChanged();
            }
        }
        private global::System.String _Prenom;
        partial void OnPrenomChanging(global::System.String value);
        partial void OnPrenomChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> CompetenceId
        {
            get
            {
                return _CompetenceId;
            }
            set
            {
                OnCompetenceIdChanging(value);
                ReportPropertyChanging("CompetenceId");
                _CompetenceId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CompetenceId");
                OnCompetenceIdChanged();
            }
        }
        private Nullable<global::System.Int32> _CompetenceId;
        partial void OnCompetenceIdChanging(Nullable<global::System.Int32> value);
        partial void OnCompetenceIdChanged();

        #endregion

    
        #region Propriétés de navigation
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ProjetFormationDebugModel", "FK_CompetencePersonne", "Competences")]
        public Competence Competence
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Competence>("ProjetFormationDebugModel.FK_CompetencePersonne", "Competences").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Competence>("ProjetFormationDebugModel.FK_CompetencePersonne", "Competences").Value = value;
            }
        }
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Competence> CompetenceReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Competence>("ProjetFormationDebugModel.FK_CompetencePersonne", "Competences");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Competence>("ProjetFormationDebugModel.FK_CompetencePersonne", "Competences", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// Aucune documentation sur les métadonnées n'est disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ProjetFormationDebugModel", Name="Projet")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Projet : EntityObject
    {
        #region Méthode de fabrique
    
        /// <summary>
        /// Créez un nouvel objet Projet.
        /// </summary>
        /// <param name="id">Valeur initiale de la propriété ID.</param>
        /// <param name="nom">Valeur initiale de la propriété Nom.</param>
        public static Projet CreateProjet(global::System.Int32 id, global::System.String nom)
        {
            Projet projet = new Projet();
            projet.ID = id;
            projet.Nom = nom;
            return projet;
        }

        #endregion

        #region Propriétés primitives
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> DateDebut
        {
            get
            {
                return _DateDebut;
            }
            set
            {
                OnDateDebutChanging(value);
                ReportPropertyChanging("DateDebut");
                _DateDebut = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateDebut");
                OnDateDebutChanged();
            }
        }
        private Nullable<global::System.DateTime> _DateDebut;
        partial void OnDateDebutChanging(Nullable<global::System.DateTime> value);
        partial void OnDateDebutChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> DateFin
        {
            get
            {
                return _DateFin;
            }
            set
            {
                OnDateFinChanging(value);
                ReportPropertyChanging("DateFin");
                _DateFin = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateFin");
                OnDateFinChanged();
            }
        }
        private Nullable<global::System.DateTime> _DateFin;
        partial void OnDateFinChanging(Nullable<global::System.DateTime> value);
        partial void OnDateFinChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Nom
        {
            get
            {
                return _Nom;
            }
            set
            {
                OnNomChanging(value);
                ReportPropertyChanging("Nom");
                _Nom = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Nom");
                OnNomChanged();
            }
        }
        private global::System.String _Nom;
        partial void OnNomChanging(global::System.String value);
        partial void OnNomChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Double> CAInitial
        {
            get
            {
                return _CAInitial;
            }
            set
            {
                OnCAInitialChanging(value);
                ReportPropertyChanging("CAInitial");
                _CAInitial = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CAInitial");
                OnCAInitialChanged();
            }
        }
        private Nullable<global::System.Double> _CAInitial;
        partial void OnCAInitialChanging(Nullable<global::System.Double> value);
        partial void OnCAInitialChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> CodeEtat
        {
            get
            {
                return _CodeEtat;
            }
            set
            {
                OnCodeEtatChanging(value);
                ReportPropertyChanging("CodeEtat");
                _CodeEtat = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CodeEtat");
                OnCodeEtatChanged();
            }
        }
        private Nullable<global::System.Int32> _CodeEtat;
        partial void OnCodeEtatChanging(Nullable<global::System.Int32> value);
        partial void OnCodeEtatChanged();

        #endregion

    
        #region Propriétés de navigation
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ProjetFormationDebugModel", "ProjetLot", "Lot")]
        public EntityCollection<Lot> Lots
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Lot>("ProjetFormationDebugModel.ProjetLot", "Lot");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Lot>("ProjetFormationDebugModel.ProjetLot", "Lot", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
