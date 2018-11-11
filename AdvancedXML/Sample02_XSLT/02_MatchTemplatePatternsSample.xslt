<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xml:space="default">
  
  <xsl:output method="text" indent="yes" />
  
  
  <xsl:template match="/">
    <xsl:value-of select="'Root!&#13;'"/>
    <xsl:apply-templates/>
  </xsl:template>
  
  <xsl:template match="*">
    <xsl:value-of select="name()"/>
    <xsl:apply-templates select="@* | node()"/>
  </xsl:template>

  <xsl:template match="@*">
    <xsl:value-of select="."/>
  </xsl:template>

  <xsl:template match="text()">
    <xsl:value-of select="concat('&lt;', . , '&gt;')"/>
  </xsl:template>


  <xsl:template match="b">!b!</xsl:template>

  
</xsl:stylesheet>
