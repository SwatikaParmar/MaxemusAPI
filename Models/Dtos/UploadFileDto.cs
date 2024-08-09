﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MaxemusAPI.Models
{
    public class UploadInstallationDocumentFileDto
    {
        public int? VariantId { get; set; }
        public int ProductId { get; set; }
        public IFormFile installationDocument { get; set; }
    }

    public class UploadMannualFileDto
    {
        public int? MannualId { get; set; }
        public int ProductId { get; set; }
        public IFormFile Mannual { get; set; }
    }

    public class UploadFileDto
    {
        public IFormFile image { get; set; }
    }
    public class UploadProfilePicDto
    {
        public IFormFile profilePic { get; set; }
        public string id { get; set; }
    }
    public partial class UploadCategoryImageDTO
    {
        public int? mainCategoryId { get; set; }
        public int? subCategoryId { get; set; }
        public IFormFile? categoryImage { get; set; }
    }
    public partial class UploadBrandImageDTO
    {
        public int brandId { get; set; }
        public IFormFile brandImage { get; set; }
    }
    public partial class UploadProductImageDTO
    {
        public int ProductId { get; set; }
        public List<IFormFile>? ProductImage { get; set; }
    }
    public partial class UploadBannerImageDTO
    {
        public int bannerId { get; set; }
        public string? name { get; set; }
        public IFormFile Image { get; set; }
    }
    public partial class UploadRewardProductImageDTO
    {
        public int rewardProductId { get; set; }
        public IFormFile? image { get; set; }
    }
    public partial class UploadDistributorDetailImageDTO
    {
        public int DistributorId { get; set; }
        public IFormFile? Image { get; set; }
    }
    public partial class UploadPaymentReceipt
    {
        public IFormFile? paymentReceipt { get; set; }
    }
    public partial class UploadQRImage
    {
        public string upidetailIds { get; set; }
        public List<IFormFile>? qrcode { get; set; }

    }
    public partial class UploadProductImageInBulkDTO
    {
        public string productIds { get; set; }
        public List<IFormFile>? productImage { get; set; }
    }
    public partial class UploadServiceImageDTO
    {
        public int serviceId { get; set; }
        // public string? Status { get; set; }
        public List<IFormFile>? salonServiceImage { get; set; }
    }
    public partial class UploadServiceIconImageDTO
    {
        public int serviceId { get; set; }
        // public string? Status { get; set; }
        public IFormFile? salonServiceIconImage { get; set; }
    }
    public partial class UploadCollectionImageDTO
    {
        public int collectionId { get; set; }
        public List<IFormFile>? collectionImage { get; set; }
    }

    public partial class GenerateImageLinkInBulkDTO
    {
        public List<IFormFile>? productImage { get; set; }
    }
    public class UploadVideoDto
    {
        public IFormFile video { get; set; }
        public IFormFile thumbnail { get; set; }
        public int DashboardVideoId { get; set; }
        public string title { get; set; }

    }

    public class UploadDashboardItemDto
    {
        public IFormFile image { get; set; }
        public IFormFile pdf { get; set; }
        public string title { get; set; }
        public string? discdescription { get; set; }
        public int dashboardItemId { get; set; }
        public string type { get; set; }
    }
}
