<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:cd="http://epam.com/learn/parody_CD"
  extension-element-prefixes="cd">

  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/cd:CD">
    <xsl:element name="CD">
      <xsl:apply-templates />
    </xsl:element>
  </xsl:template>

  <xsl:template match="cd:song">
    <xsl:element name="song">
      <xsl:value-of select="cd:title"/>
    </xsl:element>
  </xsl:template>

  <xsl:template match="text() | @*"/>
</xsl:stylesheet>