NUnit.Asserts
==================
Set of simple library with common (more or less) asserts that makes Your tests more DRY!

NUnit.Asserts.Microsoft.Owin.Security
==================
- Checking ClaimsIdentity
```csharp
ClaimsIdentityAssert.ContainsClaim(ClaimTypes.Role, "user", context.Ticket.Identity);
```

NUnit.Asserts.Compare
==================
Couple of simple Nunit asserts that compare given objects using https://www.nuget.org/packages/CompareNETObjects/

Getting Started:

- Compare objects with types check:
```csharp
CompareAssert.AreEqual(expectedObject, actualObject);
```

- Compare objects without types check:
```csharp
CompareAssert.AreSimilar(expectedObject, actualObject);
```

- Compare objects without specified properties:
```csharp
CompareAssert.AreEqual(expectedObject, actualObject, "PropertyToIgnore", "OtherPropertyToIgnore");
CompareAssert.AreSimilar(expectedObject, actualObject, "PropertyToIgnore", "OtherPropertyToIgnore");
```
