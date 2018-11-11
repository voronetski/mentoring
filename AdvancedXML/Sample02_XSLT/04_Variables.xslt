<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="text"/>
   
  <xsl:variable name="allAttrValue">
    <xsl:for-each select="//@*">
      <xsl:value-of select="."/>
    </xsl:for-each>
  </xsl:variable>

  <xsl:template match="*">
    <xsl:value-of select="name()"/>
    <xsl:value-of select="$allAttrValue"/>
    <xsl:apply-templates />
  </xsl:template>
 
</xsl:stylesheet>



