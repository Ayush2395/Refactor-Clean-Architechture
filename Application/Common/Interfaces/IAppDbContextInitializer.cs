﻿namespace Application.Common.Interfaces
{
    public interface IAppDbContextInitializer
    {
        Task InitializeAsync();
        Task SeedAsync();
    }
}
