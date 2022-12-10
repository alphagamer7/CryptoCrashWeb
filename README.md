# CryptoCrashWeb

Athif Ahamed Mohamed Shaffy: A00256229

Shivam Sharma: A00253431

# Updated Proposal

[Final Proposal for Web.pdf](https://github.com/alphagamer7/CryptoCrashWeb/files/10199352/Final.Proposal.for.Web.pdf)
Hope it could be remarked :) 

# Updates

We initiall tried to use with firebase identity, but since it took too long we decided to go with the ASP.NET with idenity approach. 
We wil use firebase storeage to upload profile picture since we did that in our android project and we could reuse the same logic.

We also thought about going with Angular, but decided against it since razorpages were quite straightforward and takes less time since there is easy support for easy scaffolding.

# Criteria points:
- Added migrations, we mistakely added wrong datatype for author and did a migration to update field. We migrated via nuget package manager console.
- Testings was started, we did a few basic test as shown in commits.
- We did basic linq query to get user details. We dint have to use too much of linq query since we did the first auxiliary goal which was to retrieve data from news orgs api.
- Login, register and user management was done via scaffolding, but we customized to have first name and last name stored as well.

Get news list
<img width="960" alt="image (1)" src="https://user-images.githubusercontent.com/17358908/206830347-41a413fd-5ef3-4864-9ca9-07ca6ff4e679.PNG">



<img width="957" alt="profile page" src="https://user-images.githubusercontent.com/17358908/206830346-8ec2c193-42c2-4597-b032-f587ecd9ced6.PNG">


DB mssql server
<img width="954" alt="db view" src="https://user-images.githubusercontent.com/17358908/206830348-f16ca9a6-b653-4e68-95dd-40622957f26a.PNG">


# Challenges faced and resolved

- DB connection, resolved it.
- Linking up razor pages, fixed that.
- API call with server, resolved that, issue was too much api calls cause timeouts from server.

 
