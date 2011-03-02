@echo off
REM =================================================================
REM Filename: prebuild.bat
REM Description: runs xsd.exe to generate C# classes
REM -----------------------------------------------------------------
REM Created by:                 Date:
REM Updated by:                 Date:
REM -----------------------------------------------------------------
REM Notes: Requires 1 parameter to set working directory to project
REM directory so that the relative paths work.
REM
REM =================================================================

cd %1

REM Global build parameters
REM -----------------------------------------------------------------

set stylesheets=..\\Intergraph.AsiaPac.Data\Stylesheets
set datamodel=.\DataModel
set schemas=.\Schemas
set eventsout=.\Events\Generated
set unitsout=.\Units\Generated

REM Build tools
REM -----------------------------------------------------------------

set xsd="C:\Program Files\Microsoft SDKs\Windows\v6.0A\bin\xsd.exe"
set xsltjs=%stylesheets%\xslt.js

REM Input data
REM -----------------------------------------------------------------

set eventmodel=%datamodel%\EventModel.xml
set unitmodel=%datamodel%\UnitModel.xml

@echo on

echo 1. Pre-process database schemas
echo -----------------------------------------------------------------

echo 1.1 Refresh the Xslt database variables


echo 1.2 Create the Xsd schemas for the datamodels


echo 1.3 Create the Xsd for the dataset
%xsltjs% %eventmodel% %stylesheets%\Dataset.xslt %eventsout%\Dataset.xsd

echo 2. Create strongly typed datasets
echo -----------------------------------------------------------------

%xsd% /dataset /n:Intergraph.AsiaPac.Data.Tests.Events %eventsout%\Dataset.xsd /out:%eventsout%

echo 3. Create C# boilerplate code
echo -----------------------------------------------------------------
