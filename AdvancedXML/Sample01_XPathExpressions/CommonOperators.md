# Common operators sample


* / - Root or delimiter "parent/child" 
```<language>
/ns:CD/ns:song/ns:title
```
* // - Search among all child nodes (at any depth)	
```<language>
//ns:title
/ns:CD/ns:song//ns:title
```
* . - Current node	
```<language>
./ns:length
```
* .. - Parent node	
```<language>
/ns:CD/ns:song//ns:title/..
```
* \* - Any element with any name	
```<language>
//*  
/ns:CD/*
```
* @ - Attribute	
```<language>
/ns:CD/@serial
```
* @* - Attribute with any name	
```<language>
//@*
```
* : - Namespace	
```<language>
/my:CD/my:song/my:parody/my:title
```
* \[ ] - Index in node set (start from 1)	
```<language>
/ns:CD/ns:song[1]/ns:title
```
* \[ ] - Filter expression	
```<language>
/ns:CD/ns:song[ns:length/ns:minutes <3]
//ns:song[ns:title = "Little mutter"]
```
* |	Union of result sets
```<language>
//ns:song | //@*
```
