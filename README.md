# fa54-projekt-as (Gruppe 3)

Entwickeln und Bereitstellen von Anwendungssystemen. Softwaresystem als 3-Schichten-Architektur (Benutzungsoberfläche, Fachkonzept, Datenhaltung).

Quellcode Dokumentation:
https://ndbiller.github.io/fa54-projekt-as

## Inhalt

* [Inhalt](#inhalt)
* [Team\- bzw\. Arbeitsteilung](#team--bzw-arbeitsteilung)
* [Problem\- und Aufgabenstellung](#problem--und-aufgabenstellung)
* [Mock\-ups](#mock-ups)
  * [TUI\-Skizze](#tui-skizze)
  * [GUI\-Skizze](#gui-skizze)
* [Funktionsbeschreibung](#funktionsbeschreibung)
* [Datenhaltung](#datenhaltung)
  * [relationale Datenbank: MSSQL](#relationale-datenbank-mssql)
  * [nicht\-relationale Datenbank: MongoDB](#nicht-relationale-datenbank-mongodb)
    * [local mongoDB server:](#local-mongodb-server)
    * [hosted mongoDB server on mLab:](#hosted-mongodb-server-on-mlab)
    * [Tables / Collections](#tables--collections)
* [ER\-Modell](#er-modell)
* [Meilensteine](#meilensteine)
* [Testszenarien](#testszenarien)

Created by [gh-md-toc](https://github.com/ekalinin/github-markdown-toc.go)

## Team- bzw. Arbeitsteilung

**Benutzungsoberfläche**: Gilad Reich  
**Fachkonzept**: Rico Krüger  
**Datenhaltung**: Andreas Biller (Teamsprecher)  

## Problem- und Aufgabenstellung

Erstellen, Darstellen und Bearbeiten von Teams und ihren Spielern sowohl über eine GUI- wie auch über eine TUI-Version des Programms. Darstellung sowohl in normaler wie auch in umgekehrter Reihenfolge über zwei verschiedene Fachkonzepte.  

## Mock-ups

### TUI-Skizze

![Text User Interface](/pictures/TUI_Mockup.png)

### GUI-Skizze

![Text User Interface](/pictures/GUI_Mockup.png)

## Funktionsbeschreibung

If Teams -> Create clicked:  
- Show *Edit/Create Window*  
- Hide *Team: Manchester United* so only name of the team textbox available.  
- After *Save* clicked, show *Unsigned Players List Window* to assign players to the new team.  
- Show *Edit/Create Window* again.  
- Hide *Name: Fred Erentz* so we can choose only available teams.  
- Update *Main Window*.  

If Teams -> Edit clicked:  
- Show *Edit/Create Window*  
- Hide *Team: Manchester United* so only name of the team textbox available.  
- Update *Main Window*.  

If Players -> Edit clicked:  
- Show *Edit/Create Window*+ as is.  
- Update *Main Window*.  

If Players -> Create clicked:  
- Show *Edit/Create Window* as is.  
- Update *Main Window*.  

If Unsigned Players clicked:  
- Show *Unsigned Players Window*.  
  If *Add To Team* clicked:  
  - Show *Edit/Create Window*.  
  - Disable *Name: Fred Erentz* text box from editing.  
  - Update *Main Window*.  

## Datenhaltung

### relationale Datenbank: MSSQL

The relational database will be added to the project as an embedded database file.  

### nicht-relationale Datenbank: MongoDB

#### local mongoDB server:

- download from [https://www.mongodb.com/](https://www.mongodb.com/) and install  
- create the folder:  
  ```shell
  C:\data\db\
  ```
- add install directory bin folder to system path  
- run server in cmd.exe with:  
  ```shell
  mongod
  ```
  (and leave it running in the background)  
- to connect to server with mongoshell in cmd.exe use:  
  ```shell
  mongo
  ```
- to use local DB with project switch from *mlab connection* in DB.cs to commented out *local connection* code  

#### hosted mongoDB server on mLab:

- reachable through mongo shell:  
  ````shell
  mongo ds241065.mlab.com:41065/as-three-tier-architecture -u <dbuser> -p <dbpassword>
  ```
- reachable in c# through mongo driver connection string:  
  ```shell
  mongodb://<dbuser>:<dbpassword>@ds241065.mlab.com:41065/as-three-tier-architecture
  ```
  set system environment variables with .env.bat, *which has been sent out to team via mail, just rename and run the file or set the values included manually*)  
  
#### Tables / Collections

To avoid mutable, growing arrays in team, we store the team reference inside the player document:  

**team collection:**  

```json
{
  "_id": "1b9db300-7f60-439e-814c-371b25155dd1",
  "name": "Team One"
}
```

**player collection:**  

```json
{
  "_id": "2e2c46f3-a588-4e80-aa48-074331c39242",
  "Name": "Player One",
  "Team": "1b9db300-7f60-439e-814c-371b25155dd1"
}
  
{
  "_id": "24bea8f8-9d4c-4eac-b808-1471f558122c",
  "Name": "Player Two",
  "Team": "1b9db300-7f60-439e-814c-371b25155dd1"
}
```

## ER-Modell

![Entitytype Relationshiptype Modell](/pictures/ER_Model.png)

## Meilensteine

**Meilenstein** | **Beschreibung** | **Zwischenprodukt** | **Datum**
--- | --- | --- | --- 
MS-1 | Anforderungsanalyse, Anforderungsdefinition | Erste Dokumentation ("Pflichtenheft") | 12.10.2017
MS-2 | Implementierung TUI, Fachkonzept1, relationale DB | Erste Version für Testszenarien | 17.11.2017
MS-3 | Implementierung GUI, Fachkonzept2, nicht-relationale DB, Tests | Referat | 04.12.2017
MS-4 | Implementierung GUI, Fachkonzept2, nicht-relationale DB, Tests | Softwareprodukt | 08.12.2017
MS-5 | Vorführung der Software | Softwareprodukt, zweite Dokumentation | 04.01.2018

## Testszenarien

- Teams auflisten
- Spieler auflisten
- Teams hinzufügen
- Spieler hinzufügen
- Teamdaten ändern
- Spielerdaten ändern
- Team löschen
- Spieler löschen
- Spielertransfer
