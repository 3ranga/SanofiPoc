# SanofiPoc
Sanofi SAP POC with Stateless state machine, Entity Framework, WebApi and React client

# Build Steps

1. Edit connection string in Sanofi.Sap.Web project Web.config file. Database will be autocreated during the first database hit.
2. Build and run the Sanofi.Sap.Web project
3. Edit the baseUrl in the `\sanofi-app\src\Services\RequestService.js` file to point to the running website. Eg: http://localhost:5000/api/requests
4. Start the React client by going to sanofi-app folder and do `npm install` then `npm start`
5. That's it. Simple huh :)