using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "description Product", 299, 3, "imagem.png");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "description Product", 299, 3, "imagem.png");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "description Product", 299, 3, "imagem.png");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. too short, minimum 3 charecters");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "description Product", 299, 3, "imagem.png");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "Product Name", "", 299, 3, "imagem.png");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description.Description is required");
        }

        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "Product Name", "de", 299, 3, "imagem.png");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. too short, minimum 5 charecters");
        }

        [Fact]
        public void CreateProduct_MissingPriceValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "Product Name", "description Product", -1, 3, "imagem.png");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact]
        public void CreateProduct_MissingStockValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "Product Name", "description Product", 299, -1, "imagem.png");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact]
        public void CreateProduct_MissingImageValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "Product Name", "description Product", 299, 3, "imagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagemimagem");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name. too long, maximum 250 charecters");
        }
    }
}