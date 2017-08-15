# VirtualPetMVC Web Application

## Overview
A web application for an interactive game-like virtual pet program. The user must be able to select different tasks or activities from a menu to care for the pet.

- [ ] VirtualPet
  - [ ] Current Status Properties
  - [ ] Animal Type
  - [ ] Name
  - [ ] Date Created

## Details
A virtual pet has these properties:

- Hunger
- Thirst
- Waste
- Boredom
- Sickness

User interaction will cause the appropriate fields to update - for instance, if they select the `Feed()` action, it will make `Hunger` go down, but make `Thirst` go up.

Other fields that might update:
  - boredom increasing
  - hunger increasing
  - sleepiness increasing

If you play with the pet, that makes it hungrier but boredom goes down.
