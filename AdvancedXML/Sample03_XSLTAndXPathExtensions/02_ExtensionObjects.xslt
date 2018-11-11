<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ext="http://epam.com/xsl/ext"
                xml:space="default">

  <xsl:output method="text" indent="yes"/>

  <xsl:template match="*">
    <xsl:value-of select="ext:GetAndInc('mycounter')"/>
    <xsl:value-of select="name()"/>
    <xsl:apply-templates />
  </xsl:template>
    
</xsl:stylesheet>
