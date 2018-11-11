<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:cd="http://epam.com/learn/parody_CD"
                xml:space="default">

  <xsl:output method="text" indent="yes"/>
 
  
  <xsl:template match="/cd:CD/cd:song/cd:title">
    <xsl:value-of select="text()"/>
    <xsl:text>&#13;</xsl:text>
  </xsl:template>

  <xsl:template match="text() | @* "/>
</xsl:stylesheet>
