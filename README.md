# Tailwind Mvc App

This guide provides step-by-step instructions for integrating Tailwind CSS into an ASP.NET 7 MVC project. Follow these steps to set up Tailwind CSS and streamline your styling workflow within your ASP.NET project.

## Requirements

- NodeJS
- .NET 7
- Terminal Emulator (Works with Powershell on Windows, and bash or zsh on Linux)

## Step 1: Create the Project

Create the ASP.NET 7 MVC project using Visual Studio or the dotnet CLI.

## Step 2: Initialize a Node Project

Start by initializing a Node.js project in your existing ASP.NET project directory:

```sh
npm init -y
```

## Step 3: Install Tailwind CSS

Add Tailwind CSS as a development dependency:

```sh
npm install -D tailwindcss
```

## Step 4: Configure CSS Build Script

Add a script to `package.json` to specify the output location for the compiled CSS:

```json
"scripts": {
    "css:build": "npx tailwindcss -i ./wwwroot/css/site.css -o ./wwwroot/css/styles.css --minify"
}
```

## Step 5: Initialize Tailwind Configuration

Initialize the Tailwind configuration file by running:

```sh
npx tailwindcss init
```

## Step 6: Configure Tailwind for Razor Pages

Update `tailwind.config.js` to include your Razor page files for Tailwind's content scan:

```js
module.exports = {
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml'
    ],
    theme: {
        extend: {},
    },
    plugins: [],
}
```

## Step 7: Include Tailwind Directives in CSS

Add the Tailwind directives to your `site.css` located in `wwwroot/css`:

```css
@tailwind base;
@tailwind components;
@tailwind utilities;
```

## Step 8: Add Build Tasks in .csproj

Update your `.csproj` file to build the CSS before deploying. Add the following `ItemGroup` and `Target` elements:

```xml
<ItemGroup>
  <UpToDateCheckBuilt Include="wwwroot/css/site.css" Set="Css" />
  <UpToDateCheckBuilt Include="tailwind.config.js" Set="Css" />
</ItemGroup>

<Target Name="Tailwind" BeforeTargets="Build">
  <Exec Command="npm run css:build"/>
</Target>
```

## Step 9: Include the Compiled CSS in Layout

Finally, include the path to the compiled CSS file in your `_Layout.cshtml` or any other view that requires Tailwind styling:

```html
<link rel="stylesheet" href="~/css/styles.css" asp-append-version="true" />
```

---

With these steps, your ASP.NET 7 MVC project is now configured to use Tailwind CSS, allowing you to take advantage of Tailwind's utility-first approach to styling.

**Reference:**
For additional details, you can refer to the [Tailwind ASP.NET MVC integration guide](https://github.com/angeldev96/tailwind-aspdotnet).