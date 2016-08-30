# Package-Installer
Coding exercise

A package installer that can handle dependencies. Given a list of packages with dependencies it gives back packages in order such that an install won’t fail due to a missing dependency.



1.
Input:
"KittenService: CamelCaser", "CamelCaser: "
Output:
CamelCaser, KittenService

2.
Input:
"KittenService: ","Leetmeme: Cyberportal","Cyberportal: Ice","CamelCaser: KittenService","Fraudstream: Leetmeme","Ice: "
Output:
Ice, KittenService, CamelCaser, Cyberportal, Leetmeme, Fraudstream

3.
Input:
"KittenService: ","Leetmeme: Cyberportal","Cyberportal: Ice","CamelCaser: KittenService","Fraudstream: ","Ice: Leetmeme"
Output:
Cycle Detected.

