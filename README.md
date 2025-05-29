# 3Innov

## **Sujet : Une solution de gestion de tickets "3.0", Gestiam**
 
Cette solution est divisée en deux parties: 
- **"TicketInterface"** : Interface client permettant à l'utilisateur de se connecter, s'inscrire, enregistrer des équipements, créer un ticket et suivre ses tickets.
- **"AdminInterface"** : Interface administrateur, reliant un site de dashboard permettant d'intervenir sur les tickets, incidents et équipements avec des fonctions administrateurs reliées à une API. 

## **Technologies utilisées :**
- JavaScript: ReactJS et NodeJS
- ASP.NET et C#
- Docker
- Nginx
- MySQL

## **Requis pour lancer le projet :**
- Visual Studio 2022
- NodeJS v22.14.0

## Lancement TicketInterface
Pour lancer TicketInterface, il suffit d'aller dans le dossier "GestiamClientRelease" et de lancer le fichier TicketInterface.exe. Il faut aussi lancer la partie administrateur en parallèle afin d'avoir accès à la base de données.

## Lancement AdminInterface
Pour lancer AdminInterface, il faut entrer la commande "**docker-compose up --build**". Le site devient accessible à partir de "localhost".
