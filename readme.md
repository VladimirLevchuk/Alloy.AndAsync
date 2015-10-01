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
1) Create page type Alloy.AndAsync.Models.Pages.TestArticlePage

![page type](/screenshots/01. Page Type.png)

2) Create view model Alloy.AndAsync.Models.ViewModels.TestArticlePageViewModel

![view model](/screenshots/02. View Model.png)

3) Create view ~/Views/TestArticlePage/Index

![view](/screenshots/03. Page View.png)

4) Create partial view ~/Views/TestArticlePage/AsyncAction

![partial view](/screenshots/04. Partial View.png)

5) Create controller

![](/screenshots/05. Controller.png) 

6) Copy Rename "Start" page to "Start.com", copy it and rename a copy root to "Start.no"

![](/screenshots/06. Start.com, Start.no.png) 

7) Configure .com site

![](/screenshots/07. .com site.png) 

8) Configure .no site

![](/screenshots/08. .no site.png) 

9) Check sites configuration

![](/screenshots/09. sites configuration.png) 

10) Create test pages

![](/screenshots/10. test pages created.png) 

11) Open /local-async-issue/

![](/screenshots/11. local-async-issue.png)  

12) Open /global-async-issue/

![](/screenshots/12. global-async-issue.png) 


Expected Result
-------------------
SiteDefinition.Current is pointing to a "alloy-and-async.com" site


Actual Result
----------------
SiteDefinition.Current is SiteDefinition.Empty inside async action


![](/screenshots/13. bug.png)  

