# *Dr. Sillystringz's Factory*

#### *Dr. Sillystringz's Factory, 5/13/2021*

#### By **Chris Ramer**

## Description

Application to help manage a factory's engineers and machines.

## Setup/Installation Requirements

Clone this repo.

Download & setup MySQL Workbench if you haven't already.

In MySQL Workbench, in *Navigator -> Administration* window, select *Data Import/Restore*.

In *Import Options* select *Import from Self-Contained File*.

Navigate to this repo's `Chris_Ramer.sql` file.

Enter the name `chris_ramer` for this database and click *Ok*.

Click *Start Import* to import the database.

With the database in your system, run terminal command `dotnet run` from the `Factory` directory. Then open `localhost:5000` in your browser.

## Specs

* **Spec:** Adding a new engineer will add that engineer to a list of all engineers
* **Input:** Engineer with name Steve
* **Output:** Redirects to page showing Steve's details
* **Spec:** Adding a new machine will add that machine to a list of all machines
* **Input:** Machine Woodchipper
* **Output:** Redirects to page showing Woodchipper details
* **Spec:** Clicking "Add engineer" link on the machine details page allows you to add engineers to that machine
* **Input:** Add engineer Mark
* **Output:** Redirects to page showing Woodchipper details with Mark now listed as an engineer for it
* **Spec:** Clicking "Add machine" link  on the engineer details page allows you to add machines to that engineer
* **Input:** Add machine Fork Lift
* **Output:** Redirects to page showing Mark's details with Fork Lift now listed as a machine for him

## Technologies Used

* C#
* ASP.NET
* .NET Core

### License

Copyright (c) 2021 **Chris Ramer**
This software is licensed under the MIT license.