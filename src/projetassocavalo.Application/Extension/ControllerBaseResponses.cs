﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OneOf;
using projetassocavalo.Application.Authentication.Responses;
using projetassocavalo.Application.Errors;
using projetassocavalo.Domain.Enums;

namespace projetassocavalo.Application.Extension;

//OneOf<LoginResponse, AppError> response
public static class ControllerBaseResponses
{
    public static IActionResult LoginResponseBase(this ControllerBase controller,
        OneOf<LoginResponse, AppError> response)
    {
        return response.Match(
            result => controller.Ok(result),
            error =>
            {
                if (error.ErrorType == TypeError.Conflict.ToString())
                {
                    return controller.Problem(statusCode: StatusCodes.Status409Conflict, title: error.detail);
                }
                if (error.ErrorType == TypeError.ValidationError.ToString())
                {
                    return ValidationProblem(controller, error);
                }

                return controller.Problem();
            }
        );
    }
       public static IActionResult RegisterResponseBase(this ControllerBase controller,
        OneOf<RegisterResponse, AppError> response)
    {
        return response.Match(
            result => controller.Created("Users/Guid", result),
            error =>
            {
                if (error.ErrorType == TypeError.Conflict.ToString())
                {
                    return controller.Problem(statusCode: StatusCodes.Status409Conflict, title: error.detail);
                }
                if (error.ErrorType == TypeError.ValidationError.ToString())
                {
                    return ValidationProblem(controller, error);
                }

                return controller.Problem();
            }
        );
    }


    private static ActionResult ValidationProblem(ControllerBase controller, AppError error)
    {
        var modelStateDictionary = new ModelStateDictionary();
        foreach (var err in error.ValidationErrors)
        {
            modelStateDictionary.AddModelError(
                err.Description, err.Code
            );
        }

        return controller.ValidationProblem(modelStateDictionary);
    }
}