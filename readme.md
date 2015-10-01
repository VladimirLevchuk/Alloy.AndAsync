Current site lost in async context in multiple site EPiServer configuration
===========================================================================

Configure environment
---------------------------

0. Create an Alloy Mvc site using extension v8.1.0.75 [Creates a new project with .NET Framework 4.5.1] (or clone a github repository)
1. *%windir%\system32\drivers\etc\hosts* file contains
>127.0.0.1	local.alloy-and-async.com local.alloy-and-async.no local.alloy-and-async.dk edit.alloy-and-async.com edit.alloy-and-async.no edit.alloy-and-async.dk

2. IIS site configured to look at *.\Alloy.AndAsync* folder (with bindings configured to accept requests from all the hostnames listed in the point 1.)
3. IIS Application Pool configured to use NET Framework 4.0 and Integrated Pipeline
4. SQL Server Express 2012 instance named '*.\SQL_2012*' installed (*)
5. Everyone has write access to the *.\Alloy.AndAsync\App_Data* folder 
6. Valid EPiServer 7 license is available at *C:\EPiServer\cms75\License.config* 

(*) - for different instance names connection string config should be changed appropriately


Steps to Reproduce
-----------------------
1. Create page type
2. Create view model
3. Create view 
4. Create partial view
5. Create controller
6. Copy Rename "Start" page to "Start.com", copy it and rename a copy root to "Start.no"
7. Configure .com site
8. Configure .no site
9. Check sites configuration
10. Create test pages
11. Open /local-async-issue/
12. Open /global-async-issue/

Actual Result
----------------
SiteDefinition.Current is SiteDefinition.Empty inside async action

Expected Result
-------------------
SiteDefinition.Current is pointing to a "alloy-and-async.com" site
