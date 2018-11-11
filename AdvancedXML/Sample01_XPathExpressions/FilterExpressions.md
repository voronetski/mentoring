# Filter expressions samples

## Checking for nodes (node exist)
```<language>
//ns:parody[ns:title]
```
```<language>
//ns:parody[not(ns:title)]
```
## Comparison
```<language>
//ns:song[ns:title = "Little mutter"]/ns:parody/ns:title
```
```<language>
//ns:song[(ns:length/ns:minutes * 60 + ns:length/ns:seconds) < 70]
```
## Functions
```<language>
//ns:title[not(local-name(..)='song')]
```
```<language>
//ns:song[normalize-space(ns:parody/ns:artist) = 'Unknown']
```