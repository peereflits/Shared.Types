![Logo](./img/peereflits-logo.png) 

# Peereflits.Shared.Types

This library/package contains types that behave like ([domain-driven-design](https://en.wikipedia.org/wiki/Domain-driven_design)) *primitive types*. These types contain self-contained rules, behaviors and data and have **no** external dependencies.

This library contains the following types:
* [AGB code](https://www.agbcode.nl) (an identifying key of Dutch healthcare providers)
* BSN number (a Dutch social-security number)
* E-mail address
* [IBAN number](https://en.wikipedia.org/wiki/International_Bank_Account_Number)
* Mime types
* Phone number (Dutch- and international phone numbers)

## Rules for adding new types

Before adding new types, keep the following rules in mind:

* This library MUST ONLY contain types that have the exact same meaning among other projects/solutions<sup>1</sup>.
* This library MUST have no dependencies (.NET BCL only).
   1. As a result this library should also be usable in Blazor.
* This library CAN be shared/used among all other projects.
* This library SHOULD only contain concrete types; no interfaces.
* All types in this library SHOULD behave as "immutable types".
* All types in this library MUST be under unit tests.

As a general rule:
* types that have the same name, meaning and behavior both inside and outside an organization are likely to be good candidates;
* types defined by external institutions or organizations<sup>2</sup> are good candidates.

---

<sup>1)</sup> A type such as "Customer number" should therefore not occur, as different definitions (format, length, use) can live within different projects (and organisations).<br />
<sup>2)</sup> For example: ISO with "country" and its [ISO country code](https://www.nationsonline.org/oneworld/country_code_list.htm)

### Version support

This library supports the following .NET versions:
1. .NET 6.0
1. .NET 7.0
1. .NET 8.0


---

<p align="center">
&copy; No copyright applicable<br />
&#174; "Peereflits" is my codename.
</p>

---
