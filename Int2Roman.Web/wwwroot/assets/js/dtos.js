"use strict";
/* Options:
Date: 2024-06-08 08:49:05
Version: 8.22
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://localhost:5001

//GlobalNamespace:
//MakePropertiesOptional: False
//AddServiceStackTypes: True
//AddResponseStatus: False
//AddImplicitVersion:
//AddDescriptionAsComments: True
//IncludeTypes:
//ExcludeTypes:
//DefaultImports:
*/
Object.defineProperty(exports, "__esModule", { value: true });
exports.UnAssignRoles = exports.AssignRoles = exports.Authenticate = exports.Register = exports.Int2RomanDTO = exports.UnAssignRolesResponse = exports.AssignRolesResponse = exports.AuthenticateResponse = exports.RegisterResponse = exports.Int2RomanDTOResponse = exports.ResponseStatus = exports.ResponseError = void 0;
// @DataContract
var ResponseError = /** @class */ (function () {
    function ResponseError(init) {
        Object.assign(this, init);
    }
    return ResponseError;
}());
exports.ResponseError = ResponseError;
// @DataContract
var ResponseStatus = /** @class */ (function () {
    function ResponseStatus(init) {
        Object.assign(this, init);
    }
    return ResponseStatus;
}());
exports.ResponseStatus = ResponseStatus;
var Int2RomanDTOResponse = /** @class */ (function () {
    function Int2RomanDTOResponse(init) {
        Object.assign(this, init);
    }
    return Int2RomanDTOResponse;
}());
exports.Int2RomanDTOResponse = Int2RomanDTOResponse;
// @DataContract
var RegisterResponse = /** @class */ (function () {
    function RegisterResponse(init) {
        Object.assign(this, init);
    }
    return RegisterResponse;
}());
exports.RegisterResponse = RegisterResponse;
// @DataContract
var AuthenticateResponse = /** @class */ (function () {
    function AuthenticateResponse(init) {
        Object.assign(this, init);
    }
    return AuthenticateResponse;
}());
exports.AuthenticateResponse = AuthenticateResponse;
// @DataContract
var AssignRolesResponse = /** @class */ (function () {
    function AssignRolesResponse(init) {
        Object.assign(this, init);
    }
    return AssignRolesResponse;
}());
exports.AssignRolesResponse = AssignRolesResponse;
// @DataContract
var UnAssignRolesResponse = /** @class */ (function () {
    function UnAssignRolesResponse(init) {
        Object.assign(this, init);
    }
    return UnAssignRolesResponse;
}());
exports.UnAssignRolesResponse = UnAssignRolesResponse;
// @Route("/calculate/roman")
var Int2RomanDTO = /** @class */ (function () {
    function Int2RomanDTO(init) {
        Object.assign(this, init);
    }
    Int2RomanDTO.prototype.getTypeName = function () { return 'Int2RomanDTO'; };
    Int2RomanDTO.prototype.getMethod = function () { return 'POST'; };
    Int2RomanDTO.prototype.createResponse = function () { return new Int2RomanDTOResponse(); };
    return Int2RomanDTO;
}());
exports.Int2RomanDTO = Int2RomanDTO;
/** @description Sign Up */
// @Route("/register", "PUT,POST")
// @Api(Description="Sign Up")
// @DataContract
var Register = /** @class */ (function () {
    function Register(init) {
        Object.assign(this, init);
    }
    Register.prototype.getTypeName = function () { return 'Register'; };
    Register.prototype.getMethod = function () { return 'POST'; };
    Register.prototype.createResponse = function () { return new RegisterResponse(); };
    return Register;
}());
exports.Register = Register;
/** @description Sign In */
// @Route("/auth", "GET,POST")
// @Route("/auth/{provider}", "GET,POST")
// @Api(Description="Sign In")
// @DataContract
var Authenticate = /** @class */ (function () {
    function Authenticate(init) {
        Object.assign(this, init);
    }
    Authenticate.prototype.getTypeName = function () { return 'Authenticate'; };
    Authenticate.prototype.getMethod = function () { return 'POST'; };
    Authenticate.prototype.createResponse = function () { return new AuthenticateResponse(); };
    return Authenticate;
}());
exports.Authenticate = Authenticate;
// @Route("/assignroles", "POST")
// @DataContract
var AssignRoles = /** @class */ (function () {
    function AssignRoles(init) {
        Object.assign(this, init);
    }
    AssignRoles.prototype.getTypeName = function () { return 'AssignRoles'; };
    AssignRoles.prototype.getMethod = function () { return 'POST'; };
    AssignRoles.prototype.createResponse = function () { return new AssignRolesResponse(); };
    return AssignRoles;
}());
exports.AssignRoles = AssignRoles;
// @Route("/unassignroles", "POST")
// @DataContract
var UnAssignRoles = /** @class */ (function () {
    function UnAssignRoles(init) {
        Object.assign(this, init);
    }
    UnAssignRoles.prototype.getTypeName = function () { return 'UnAssignRoles'; };
    UnAssignRoles.prototype.getMethod = function () { return 'POST'; };
    UnAssignRoles.prototype.createResponse = function () { return new UnAssignRolesResponse(); };
    return UnAssignRoles;
}());
exports.UnAssignRoles = UnAssignRoles;
