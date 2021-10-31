
const constants = {
    PPT_API_HOST: process.env.PPT_API_HOST || "http://localhost:8082",
    PPT_API_VERSION: process.env.PPT_API_VERSION || "v1",

    SESSION_TOKEN_KEY: "PPT.API-SessionToken",

    DEFAULT_USER_STATUS: 1, // New
    DEFAULT_USER_TYPE: 1, // Customer
    DEFAULT_CONTACT_TYPE: 1, // Email
    DEFAULT_CONTACT_TITLE: "Main Email",
    
    //******** HTTP ERROR CODES ************************
    HTTP_OK: 200,
    HTTP_Created: 201,
    HTTP_NoContent: 204,
    HTTP_BadRequest: 400,
    HTTP_Unauthorized: 401,
    HTTP_Forbidden: 403,
    HTTP_NotFound: 404,
    HTTP_IntServerError: 500,
    HTTP_NotImplemented: 501
}

module.exports = constants;