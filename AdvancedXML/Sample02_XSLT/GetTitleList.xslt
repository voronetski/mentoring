<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:cd="http://epam.com/learn/parody_CD"
  extension-element-prefixes="cd">

  <xsl:output indent="yes"/>
  
  <xsl:param name="Date" select="''"/>
  
  <xsl:template match="/cd:CD">
    <xsl:element name="CD">
      <xsl:attribute name="date">
        <xsl:value-of select="$Date"/>
      </xsl:attribute>
      <xsl:apply-templates />
    </xsl:element>
  </xsl:template>

  <xsl:template match="cd:song">
    <song>
      <xsl:value-of select="cd:title"/>
    </song>
  </xsl:template>

  <xsl:template match="text() | @*"/>
</xsl:stylesheet>
