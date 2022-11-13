# https://www.npmjs.com/package/ 
$project="clientapp"

# toolchain builds SPA
npx create-react-app $project --template typescript
Set-Location $project

#install packages 
npm install axios

$project="clientapp"
Set-Location $project
npm start

# npm run build runs build from package.json
# to move build files to wwwroot of web app, include the following
# "postbuild": "move build ../WebApi1/wwwroot",
npm run build

# program.cs
# app.UseDefaultFiles(); //looks for index.html in wwwroot folder
# app.UseStaticFiles(); //serve static files from wwwroot
# launchSettings.json  "launchUrl": "",
dotnet watch run --project "WebApi1"
start-process https://localhost:7194