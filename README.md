# MultiTool Project – Console App  
_Ett projekt med fokus på arkitektur och agila arbetsmetoder._

## Länk till Trello: https://trello.com/b/PtV6ETBQ/consoleapp

Detta projekt är utvecklat i C# med Visual Studio och följer principerna för OOP, design patterns och Dependency Injection.

---

## 📦 **Projektstruktur**
Lösningen består av **4 fristående konsolapplikationer**:

- **Client**  
  - Startapplikation som låter användaren navigera till de övriga apparna.
  - Kan även starta Shapes, RPS eller Calculator direkt.

- **RPS (Sten, Sax, Påse)**  
  - Spela mot datorn; resultat och statistik sparas i databasen.

- **Shapes**  
  - Beräkna area och omkrets för olika former. CRUD-stöd och Strategy Pattern används.

- **Calculator**  
  - Utför beräkningar med operatorerna +, -, *, /, √ och %. CRUD-stöd och Strategy Pattern används.

Alla projekt delar:

- **Service-lager**  
  - Innehåller affärslogik och hanterar mappning mellan DTO’s och entiteter.

- **DataAccessLayer (DAL)**  
  - Innehåller entiteter, DTO’s och databaslogik med EF Core Code First.

---

## 🔨 **Tekniker och Arkitektur**
- **C# med .NET Core Console Apps**
- **Entity Framework Core Code First**
- **Spectre.Console** för visuell upplevelse i konsolen.
- **DTO’s**  
  - Används i alla CRUD-operationer för att separera presentation och datamodell.
- **Autofac**  
  - Dependency Injection används i samtliga projekt för att lösa beroenden.
- **Design Patterns**  
  - **Strategy Pattern** används i Shapes och Calculator för flexibel logikhantering.
- **appsettings.json**  
  - Varje projekt har en egen konfiguration för databasanslutning.

---

## 📑 **Funktionalitet**
✅ Shapes och Calculator har CRUD-stöd.  
✅ RPS har stöd för att visa lista över spelade matcher (ej CRUD).  
✅ Samtliga appar har användarvänliga och visuellt tilltalande menyer.  
✅ Användarinmatning valideras och fel hanteras på ett tydligt sätt.  

---

## 🔗 **Metoder, Patterns och Principer**
- **OOP:** Alla appar är objektorienterade med tydliga klasser och metoder.  
- **SOLID:** Projekten är designade för att vara lätta att förstå, underhålla och vidareutveckla.  
- **Dependency Injection:** Autofac används för att koppla ihop klasser och services.  
- **DTO’s:** Används för att isolera datamodellen från presentationen.  
- **DRY-principen:** Återanvändning av kod via Service-lagret och DAL.  
- **Strategy Pattern:** Implementerat i Shapes och Calculator för flexibel beräkningslogik.

---

## 🚀 **Installation**
1. Klona repot från GitHub.  
2. Öppna lösningen i Visual Studio.  
3. Bygg hela solutionen (Ctrl + Shift + B) för att generera exekverbara filer.  
4. Kontrollera databasanslutningen i varje `appsettings.json` för din miljö.  
5. Starta Client-appen för att nå de övriga apparna, eller starta dem direkt.

---

## 📝 **Övrigt**
- Relevanta commits och feature branches finns dokumenterade i GitHub.  
- Dagbok över utvecklingen finns bifogad i repot.
