<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:template match='/'>
    <html>
	<body>
        <xsl:apply-templates />
	</body>
    </html>
  </xsl:template>

  <xsl:template match="libro">
     <p><xsl:value-of select="titulo"/> - <xsl:value-of select="autor"/></p>
	 <p><img>
    <xsl:attribute name="src">
      <xsl:value-of select="imagen" />
    </xsl:attribute>
    </img>
    </p>
	
  </xsl:template>



  

</xsl:stylesheet>
 

