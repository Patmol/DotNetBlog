---
title: "Why I've created a blog generator?"
author: "Patmol"
date: 2021-06-12 14:00:00 +0200
categories: [Development]
tags: [development, web, dotnetblog]
---

## What's a blog generator?

A blog generator will take various files and generates a static HTML site. The files used by the generator will depend on this one but in our case, it will be a mix of HTML/CSS/JS files for the structure of the blog and markdown files for the content of it.

For me, the advantage of the blog generator over a CMS like WordPress is the lightness of the system. Once the blog template is done (and you can take an existing one), you need to write the post in markdown files, build the blog and publish it. Easy :-)


## Why create my one?

In the past, I used [Jekyll](http://jekyllrb.com/ "Jekyll"), a really well-known - and with a lot of qualities - blog generator. But Jekyll has some prerequisites that make the use of it not as friendly I would like.

Indeed, I'm not using Ruby or RubyGems every day, and when I've tried to reinstall it, this got a little messy, and I could not build my blog.
It's my fault; I've probably done something that I should not during the installation process, but it bothers me, and so, I've asked myself why not build my blog generator.


## What technologies used?

There are two parts to the _DotNetBlog_ project. 
The first one is the blog itself and its content. This part uses HTML and CSS for the template and Markdown for the content, just standard technologies for this kind of stuff.

The second part is the blog generator. The generation of the blog itself is the most challenging part of the project but also the most fun to work on.
The blog generator is built with .NET Core, in C#, with various packages to avoid reinventing the wheel. I've chosen to use .NET Core to make the project available on every OS and easy to use. 
As a madder of fact, the goal is only to install the .NET CLI and a NuGet package, then have to run a command to build (or test) your blog. 


## What's next?

This blog is built with _DotNetBlog_ but the project is far from over. 

The blog built is elementary; I need to review the accessibility of the generated HTML, add a sitemap, a search function, and a lot of features.
So, it's a very early version that I'm using, but if I want to improve my generator, I need to use it to see what's working right and what can be improved.



> This project is open-source; [you can find the code on GitHub](https://github.com/Patmol/DotNetBlog "GitHub").
