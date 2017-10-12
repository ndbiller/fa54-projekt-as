# fa54-projekt-as (Gruppe 3)

Entwickeln und Bereitstellen von Anwendungssystemen. Softwaresystem als 3-Schichten-Architektur (Benutzungsoberfläche, Fachkonzept, Datenhaltung).

## Inhalt

* [Inhalt](#inhalt)
* [Team\- bzw\. Arbeitsteilung (Gruppe 3)](#team--bzw-arbeitsteilung-gruppe-3)
* [Problem\- und Aufgabenstellung](#problem--und-aufgabenstellung)
* [Mock\-ups](#mock-ups)
  * [TUI\-Skizze](#tui-skizze)
  * [GUI\-Skizze](#gui-skizze)
* [Funktionsbeschreibung](#funktionsbeschreibung)
* [Datenhaltung](#datenhaltung)
* [ER\-Model](#er-model)
* [Meilensteine](#meilensteine)
* [Testszenarien](#testszenarien)


Created by [gh-md-toc](https://github.com/ekalinin/github-markdown-toc.go)

## Team- bzw. Arbeitsteilung

**Benutzungsoberfläche**: Gilad Reich  
**Fachkonzept**: Rico Krüger  
**Datenhaltung**: Andreas Biller (Teamsprecher)  

## Problem- und Aufgabenstellung

Speichern, Darstellen und Bearbeiten von Teams und Spielern.

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

- relationale Datenbank: MySQL
- nicht-relationale Datenbank: MongoDB

## ER-Model

![Entity Relationship Model](/pictures/ER_Model.png)

## Meilensteine

**Meilenstein** | **Beschreibung** | **Zwischenprodukt** | **Datum**
--- | --- | --- | --- 
MS-1 | Anforderungsanalyse, Anforderungsdefinition | Erste Dokumentation ("Pflichtenheft") | 12.10.2017
MS-2 | Implementierung TUI, Fachkonzept1, relationale DB | Erste Version für Testszenarien | 17.01.2017
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

