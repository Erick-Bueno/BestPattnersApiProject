﻿namespace projetassocavalo.Application.Authentication.Requests;

public record LoginRequest(
    string Email,
    string Password
);