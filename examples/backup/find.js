
const request = require("requestretry");
const async = require('async');
const fs = require('fs-extra');
const moment = require('moment');
const path = require("path");

const backupFile = require("./backup.json");

const findHierarchicalEntities = (value) =>{

  const hierarchicalEntityObjects = value.entities.filter(entity => {
    if (entity.children) {
      return entity.name;
    }
  });

  return hierarchicalEntityObjects.map(x => x.name);
}

const findCompositeEntities = (value) =>{

  return value.composites.map(composite => {
      return composite.name;
  });
}

// find all apps with heirarchical entities
backupFile.apps.forEach(app => {

  app.properties.forEach(property => {

    if(property.route == 'versionExports'){

      // get version name
      property.values.forEach(value => {

          // check version for deprecated items
          const name = value.name;
          const version = value.versionId;

          const hierarchicalEntities = findHierarchicalEntities(value);
          hierarchicalEntities.length>0? console.log(`'${name}' '${version}' 'HIER=${hierarchicalEntities.join(",")}'`) : null;

          const compositeEntities = findCompositeEntities(value);
          compositeEntities.length>0? console.log(`'${name}' '${version}' 'COMP=${compositeEntities.join(",")}'`) : null;       
      })
    }
  });
});
