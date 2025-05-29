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
Pour lancer AdminInterface, il faut entrer la commande "**docker-compose up --build**" à partir de la racine du dossier. Le site devient accessible à partir de "localhost".

## Vidéo de démonstration Gestiam
[![Démonstration Gestiam.mp4 - Google Drive](https://drive.google.com/thumbnail?authuser=0&sz=w1280&id=1EIpQ02dKbsV6Av4Z78NM_C-PTgb5z0WT)](https://drive.google.com/file/d/1EIpQ02dKbsV6Av4Z78NM_C-PTgb5z0WT/view "Démonstration Gestiam.mp4 - Google Drive")
