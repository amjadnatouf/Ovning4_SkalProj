# Övning 4 - Minneshantering 

## Teori och fakta

### Frågor
### 1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion.
#### Stacken:
- fungerar som en trave med LIFO ( Sist in Först ut).
- Lagrar metodanrop, lokala variabler och parameter.
- Minnet sköts automatiskt när metoden avslutas.

#### Exampel:
```csharp
void test()
{
    int x = 5; // x ligger på stacken
} // x försvinner här
```

#### Heapen:
- Dynamisk minnesstruktur.
- Används för objekt som skapas med new.
- Variabeln håller bara en referens till objektet på heapen.
- Minnet hanteras av Garbage Collector (GC).
- Större men långsammare än stacken.
 
#### Exampel:
```csharp
class Person { public string Name; }

void test()
{
    Person p = new Person(); // Person-objektet ligger på heapen
    p.Name = "Anna";
} // referensen p försvinner, objektet kan senare städas av GC
```

### 2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
#### Value Types
- Inhåller själva värdet direkt.
- Lagras där de deklareras
- Vid tilldelning kopieras värdet.
- Ex: int, double, bool, struct, enum.

#### Reference Types (referenstyper)
- Inhåller en refernce som peker till objektet.
- Själva objektet lagras på heapen.
- Vid tilldelning kopieras referensen, inte objektet.
- Referensen kan ligga på stacken.
- Ex: class, string, array, delegate.

##### Skillnad: 
- Value Type: int a = 10; int b = a; får en kopia av värdet 10.
- Reference Type: Class A = new Class(); Class B = A; B peaker på samma objekt.

### 3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför? 
#### Användar int value type
- x = 3; y = x; kopiera värdet.
- y = 4; ändrar bara y.
- retrun x; retunerar 3 där x har inte förändrats.

#### Användar MyInt referense type
- x = new MyInt(); x.MyValue = 3;
- y = x kopierar referense men båda peker på samma objekt.
- y.MyValue = 4; ändrar objekt som båda x, y pekar på.
- retrun x.MyValue; retunerar 4 där y har förändrats objekt value.