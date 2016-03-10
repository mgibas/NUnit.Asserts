<a href="https://www.gitcheese.com/app/#/projects/835d8d29-aae2-431a-944a-c4b8fa6b4b5d/pledges/create" target="_blank" style="float:left;" > <img src="https://api.gitcheese.com/v1/projects/835d8d29-aae2-431a-944a-c4b8fa6b4b5d/badges" width="200px" /> </a>
NUnit.Asserts [![Build status](https://ci.appveyor.com/api/projects/status/w8uem84janv84u5o?retina=true)](https://ci.appveyor.com/project/mgibas/nunit-asserts)
==================
Set of simple libraries with common (more or less) asserts that makes Your tests more DRY!

NuGets
====
```
Install-Package NUnit.Asserts.Microsoft.Owin.Security
Install-Package NUnit.Asserts.Compare
```

NUnit.Asserts.Microsoft.Owin.Security
==================
Asserts that help to examine ClaimsIdentity object

- Checking ClaimsIdentity
```csharp
ClaimsIdentityAssert.ContainsClaim(ClaimTypes.Role, "user", context.Ticket.Identity);
ClaimsIdentityAssert.DoesNotContainClaim(ClaimTypes.Role, "user", context.Ticket.Identity);
```

NUnit.Asserts.Compare
==================
Couple of simple Nunit asserts that compare given objects using https://www.nuget.org/packages/CompareNETObjects/

- Compare objects
```csharp
Assert.That(actualObject, Compares.To(expected));
```

- Assert object is contained in collection
```csharp
Assert.That(actualObject, Compares.ToAnyIn(list));
```

- Ignore property
```csharp
Assert.That(actualObject, Compares.To(expected).IgnoreProperty(p => p.Some));
```

- Ignore type checking
```csharp
Assert.That(actualObject, Compares.To(expected).WithoutTypeChecking());
```

- Compare objects with types check:
```csharp
CompareAssert.AreEqual(expectedObject, actualObject);
```

- Compare objects without types check:
```csharp
CompareAssert.AreEquivalent(expectedObject, actualObject);
```

- Compare objects without specified properties:
```csharp
CompareAssert.AreEqual(expectedObject, actualObject, p => p.PropertyToIgnore, p => p.OtherPropertyToIgnore);
CompareAssert.AreEquivalent(expectedObject, actualObject, p => p.PropertyToIgnore, p => p.OtherPropertyToIgnore);
CompareAssert.AreEqual(expectedObject, actualObject, "PropertyToIgnore", "OtherPropertyToIgnore");
CompareAssert.AreEquivalent(expectedObject, actualObject, "PropertyToIgnore", "OtherPropertyToIgnore");
```
