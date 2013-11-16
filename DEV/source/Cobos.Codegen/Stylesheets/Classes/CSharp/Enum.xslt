﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
					 xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
					 xmlns:msxsl="urn:schemas-microsoft-com:xslt"
					 xmlns:cobos="http://schemas.cobos.co.uk/datamodel/1.0.0"
					 xmlns="http://schemas.cobos.co.uk/datamodel/1.0.0"
					 xmlns:xsd="http://www.w3.org/2001/XMLSchema"
					 exclude-result-prefixes="msxsl">
  <xsl:output method="text" indent="no" encoding="utf-8"/>
  <xsl:strip-space elements="*"/>
  <!-- 
	============================================================================
	Filename: Enum.xslt
	Description: Convert XSD enumerations to C# enum
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	Created by:	N.Davis						Date: 2010-08-12
	Updated by:									Date:
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	Notes:	
	
	
	============================================================================
	-->

  <xsl:param name="namespace"/>
  <xsl:param name="prefix"/>

  <!-- 
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	Match the root of the schema
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	-->

  <xsl:template match="/xsd:schema">
    <xsl:apply-templates select="./xsd:element[.//*[ self::xsd:enumeration ]]"/>
  </xsl:template>

  <xsl:template match="/xsd:schema" mode="file">
// This code was generated by a tool.

// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.

using System;

namespace <xsl:value-of select="$namespace"/>
{
		<xsl:apply-templates select="./xsd:element[.//*[ self::xsd:enumeration ]]"/>
}
  </xsl:template>
  <!-- 
  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  Convert a enumerated type
  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  -->

  <xsl:template match="xsd:element">
	public enum <xsl:value-of select="$prefix"/><xsl:value-of select="@name"/>
	{
		<xsl:apply-templates select=".//xsd:enumeration"/>
	}
  </xsl:template>
	<!-- 
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	Output each enumerated value
	~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	-->
  <xsl:template match="xsd:enumeration">
    <xsl:value-of select="@value"/>
    <xsl:if test="not( position() = last() )">,
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>
