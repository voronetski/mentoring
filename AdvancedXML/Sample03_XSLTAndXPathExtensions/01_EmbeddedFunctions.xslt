<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:cd="http://epam.com/learn/parody_CD" 
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"  
                xmlns:user="urn:my-scripts"
                extension-element-prefixes="cd" exclude-result-prefixes="cd" >

  <msxsl:script implements-prefix='user' language='CSharp'>
    <![CDATA[
    public string curYear() {
      return System.DateTime.UtcNow.Year.ToString();
    }]]>
  </msxsl:script>

  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/cd:CD">
    <xsl:element name="cd:CD">
      <xsl:attribute name="year">
        <xsl:value-of select="user:curYear()"/>
      </xsl:attribute>
      <xsl:copy-of select="cd:*" />
    </xsl:element>
  </xsl:template>

</xsl:stylesheet>

