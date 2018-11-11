<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:cd="http://epam.com/learn/parody_CD"
  extension-element-prefixes="cd">
  
  <xsl:output method="xml" indent="yes"/>
  
  <xsl:template match="/cd:CD">
    <CD>
      <xsl:apply-templates />
    </CD>
  </xsl:template>

  <xsl:template match="cd:song">
    <song>
      <xsl:value-of select="cd:title"/>
    </song>
  </xsl:template>

  <xsl:template match="text() | @*"/>
</xsl:stylesheet>
