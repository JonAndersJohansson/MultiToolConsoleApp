# MultiTool Project – Console App  - Ett project med fokus på arkitektur och agila arbetsmetoder.

Projektet är utvecklat i C# med Visual Studio och följer principerna för OOP, design patterns och Dependency Injection.

---

## 📦 **Projektstruktur**
Lösningen består av **4 fristående konsolapplikationer**:
- **Client**  
  - Startapplikation som låter användaren navigera till de övriga apparna.
  - Kan även starta Shapes, RPS eller Calculator direkt.
- **RPS (Sten, Sax, Påse)**  
  - Spela mot datorn, resultat och statistik sparas i databasen.
- **Shapes**  
  - Beräkna area och omkrets för olika former. CRUD-stöd och Strategy Pattern används.
- **Calculator**  
  - Utför beräkningar med operatorer +, -, *, /, √ och %. CRUD-stöd och Strategy Pattern används.

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
  - Alla CRUD-operationer använder DTO’s för att separera presentation och datamodell.
- **Autofac**  
  - Dependency Injection används i samtliga projekt för att lösa beroenden.
- **Design Patterns**
  - **Strategy Pattern** används i Shapes och Calculator för flexibel logikhantering.
- **appsettings.json**  
  - Varje projekt har sin egen konfiguration för databasanslutning.

---

## 📑 **Funktionalitet**
✅ Shapes och Calculator har CRUD-stöd.  
✅ RPS har stöd för att visa lista över spelade matcher (ej CRUD).  
✅ Alla projekt har menyer som är användarvänliga och visuellt tilltalande.  
✅ Apparna validerar användarinmatning och hanterar fel på ett tydligt sätt.  

---

## 🔗 **Metoder, patterns och principer**
- **OOP:** Alla appar är objektorienterade med tydliga klasser och metoder.  
- **SOLID:** Projekten är designade för att vara lätta att förstå, underhålla och utöka.  
- **Dependency Injection:** Autofac används för att koppla ihop klasser och services.  
- **DTO’s:** Alla CRUD-operationer använder DTO’s för att isolera datamodellen.  
- **DRY-principen:** Återanvändning av kod mellan apparna via Service-lagret och DAL.  
- **Strategy Pattern:** Används i Shapes och Calculator för att hantera olika beräkningar.

---

## 🚀 **Installation**
1. Klona repot från GitHub.
2. Öppna lösningen i Visual Studio.
3. Säkerställ att exe-filerna för varje app existerar genom att Bulida hela Solution (CTRL + SHIFT + B)
4. Säkerställ att databasanslutningen i varje appsettings.json är korrekt för din miljö.
6. Starta Client-app för att komma åt de andra apparna (eller starta dem direkt).

---

## 📝 **Övrigt** 
- Relevanta commits och feature branches finns i GitHub.  
- Dagbok över utvecklingen finns bifogad i repot.
