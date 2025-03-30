Projet de Gestion de Stock - Application Desktop en C#
Description
Cette application de bureau, développée en C# avec Windows Forms/WPF, permet la gestion efficace des stocks dans une entreprise. Elle offre des fonctionnalités 
pour suivre les produits, gérer les fournisseurs et surveiller les mouvements d'entrée et de sortie des marchandises.

Structure du Projet
/Models : Définit les entités comme Produit, Fournisseur, et MouvementStock.

/Views : Contient les interfaces utilisateur (Windows Forms ou XAML).

/Controllers : Contient la logique métier et les interactions avec la base de données.

/Data : Gère les connexions à la base de données.

Connexion : Accédez à l'interface de connexion pour vous identifier.

Dashboard : Visualisez les statistiques et les indicateurs clés (produits faibles en stock, mouvements récents, etc.).

Gestion : Utilisez les onglets dédiés pour gérer les produits, les fournisseurs et les mouvements de stock.

Clonez le projet :

bash
git clone https://github.com/nom-utilisateur/gestion-stock.git
cd gestion-stock
Ouvrez le fichier solution (.sln) dans Visual Studio.

Configurez la connexion à la base de données dans le fichier appsettings.json ou dans une configuration personnalisée.

Lancez l'application en appuyant sur F5.

Prérequis
Avant de commencer, assurez-vous d'avoir installé :

[ ] Visual Studio (2019 ou supérieur).

[ ] Le SDK .NET Framework ou .NET Core.

[ ] Une base de données locale ou distante (SQLite, MySQL ou SQL Server).

Langage : C#

Framework : .NET Framework / .NET Core

Interface utilisateur : Windows Forms ou WPF

Base de données : SQLite / MySQL / SQL Server (selon votre configuration)

Bibliothèques tierces :

iTextSharp (pour générer des rapports PDF)

ClosedXML (pour les fichiers Excel)

Fonctionnalités
Gestion des produits :

Ajout, modification et suppression de produits.

Recherche par nom, catégorie ou référence.

Suivi des niveaux de stock.

Gestion des fournisseurs :

Création et mise à jour des informations des fournisseurs.

Suivi des commandes par fournisseur.

Mouvements de stock :

Enregistrement des entrées et sorties de produits.

Génération de rapports sur les mouvements de stock.

Rapports et exports :

Génération de rapports au format PDF/Excel.

Export des données de stock pour analyse.
