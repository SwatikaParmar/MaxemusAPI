﻿using AutoMapper;
using MaxemusAPI.Dtos;
using MaxemusAPI.Models;
using MaxemusAPI.Models.Dtos;
using MaxemusAPI.Repository;
using MaxemusAPI.Repository.IRepository;
using MaxemusAPI.ViewModel;

namespace MaxemusAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<UserDTO, ApplicationUser>().ReverseMap();
            CreateMap<LoginResponseDTO, ApplicationUser>().ReverseMap();
            CreateMap<LoginResponseDTO, ApplicationUser>().ReverseMap();
            CreateMap<DealerDetailDTO, DealerDetail>().ReverseMap();
            CreateMap<DealerProductDTO, DealerProduct>().ReverseMap();
            CreateMap<DealerProfileDTO, DealerDetail>().ReverseMap();
            CreateMap<DealerDetailDTO, ApplicationUser>().ReverseMap();
            CreateMap<DealerProfileDTO, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, DistributorAddress>().ReverseMap();
            CreateMap<UserDetailDTO, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, UserRequestDTO>().ReverseMap();
            CreateMap<Notification, NotificationDTO>().ReverseMap();
            CreateMap<NotificationDTO, Notification>().ReverseMap();
            CreateMap<NotificationSent, NotificationSentDTO>().ReverseMap();
            CreateMap<NotificationSentDTO, NotificationSent>().ReverseMap();
            CreateMap<InstallationDocumentDTO, InstallationDocumentVariants>().ReverseMap();

            CreateMap<ProductStockResponseDTO, ProductStock>().ReverseMap();

            CreateMap<DistributorDetailsDTO, ApplicationUser>().ReverseMap();
            CreateMap<UserResponseDTO, ApplicationUser>().ReverseMap();
            CreateMap<DistributorDetailsDTO, DistributorDetail>().ReverseMap();
            CreateMap<DistributorAddressDTO, DistributorAddress>().ReverseMap();
            CreateMap<DistributorDetail, DistributorDetailsDTO>().ReverseMap();
            CreateMap<DistributorAddress, DistributorAddressDTO>().ReverseMap();

            CreateMap<DealerUserListDTO, ApplicationUser>().ReverseMap();
            CreateMap<DealerUserListDTO, DealerDetail>().ReverseMap();

            CreateMap<UserResponseDTO, ApplicationUser>().ReverseMap();
            CreateMap<UserResponseDTO, DistributorAddress>().ReverseMap();
            CreateMap<UserResponseDTO, DistributorDetail>().ReverseMap();
            CreateMap<DistributorBusinessResponseDTO, DistributorAddress>().ReverseMap();
            CreateMap<DistributorBusinessResponseDTO, DistributorDetail>().ReverseMap();
            CreateMap<DistributorBusinessResponseDTO, ApplicationUser>().ReverseMap();

            CreateMap<DistributorRequestDTO, ApplicationUser>().ReverseMap();
            CreateMap<UserRequestDTO, ApplicationUser>().ReverseMap();
            CreateMap<UserRequestDTO, DistributorAddress>().ReverseMap();
            CreateMap<UserRequestDTO, DistributorDetail>().ReverseMap();
            CreateMap<DistributorBusinessRequestDTO, DistributorAddress>().ReverseMap();
            CreateMap<DistributorBusinessRequestDTO, DistributorDetail>().ReverseMap();
            CreateMap<DistributorBusinessRequestDTO, ApplicationUser>().ReverseMap();

            CreateMap<CategoryImageDTO, MainCategory>().ReverseMap();
            CreateMap<CategoryImageDTO, SubCategory>().ReverseMap();


            CreateMap<CartResponseDTO, CartDetail>().ReverseMap();
            CreateMap<CartResponseDTO, Product>().ReverseMap();
            CreateMap<ProductListFromCart, Product>().ReverseMap();
            CreateMap<ProductListFromCart, CartDetail>().ReverseMap();
            CreateMap<ProductResponseDTO, CartDetail>().ReverseMap();
            CreateMap<ProductResponselistDTO, Product>().ReverseMap();
            CreateMap<ProductResponselistDTO, MainCategory>().ReverseMap();
            CreateMap<ProductResponselistDTO, SubCategory>().ReverseMap();
            CreateMap<CategoryResponseDTO, MainCategory>().ReverseMap();
            CreateMap<CategoryResponseDTO, SubCategory>().ReverseMap();
            CreateMap<DistributorUserListDTO, ApplicationUser>().ReverseMap();
            CreateMap<DistributorUserListDTO, DistributorDetail>().ReverseMap();

            CreateMap<DealerResponseDTO, ApplicationUser>().ReverseMap();
            CreateMap<DealerRequestDTO, ApplicationUser>().ReverseMap();
            CreateMap<DealerRequestDTO, DealerDetail>().ReverseMap();
            CreateMap<DealerResponseDTO, DealerDetail>().ReverseMap();

            CreateMap<OrderResponseDTO, DistributorOrder>().ReverseMap();
            CreateMap<DistributorOrderedListDTO, DistributorOrder>().ReverseMap();

            CreateMap<DistributorOrderedProductDTO, DistributorOrderedProduct>().ReverseMap();
            CreateMap<DistributorOrderDetailDTO, DistributorOrderedProduct>().ReverseMap();
            CreateMap<DistributorOrderedProductDTO, DistributorOrder>().ReverseMap();
            CreateMap<DistributorOrderDetailDTO, DistributorOrder>().ReverseMap();


            CreateMap<AddBrandDTO, Brand>().ReverseMap();
            CreateMap<BrandDTO, Brand>().ReverseMap();
            CreateMap<BrandListDTO, Brand>().ReverseMap();


            CreateMap<CategoryRequestDTO, MainCategory>().ReverseMap();
            CreateMap<DeleteCategoryDTO, MainCategory>().ReverseMap();
            CreateMap<GetCategoryRequestDTO, MainCategory>().ReverseMap();
            CreateMap<GetCategoryDetailRequestDTO, MainCategory>().ReverseMap();
            CreateMap<AddCategoryDTO, MainCategory>().ReverseMap();
            CreateMap<CategoryDTO, MainCategory>().ReverseMap();
            CreateMap<UpdateCategoryDTO, MainCategory>().ReverseMap();

            CreateMap<AddCategoryDTO, SubCategory>().ReverseMap();
            CreateMap<DeleteCategoryDTO, SubCategory>().ReverseMap();
            CreateMap<CategoryDTO, SubCategory>().ReverseMap();
            CreateMap<CategoryRequestDTO, SubCategory>().ReverseMap();
            CreateMap<GetCategoryRequestDTO, SubCategory>().ReverseMap();
            CreateMap<GetCategoryDetailRequestDTO, SubCategory>().ReverseMap();
            CreateMap<UpdateCategoryDTO, SubCategory>().ReverseMap();


            CreateMap<AdminResponseDTO, CompanyDetail>().ReverseMap();
            CreateMap<AdminResponseDTO, ApplicationUser>().ReverseMap();
            CreateMap<CompanyDetail, ApplicationUser>().ReverseMap();
            CreateMap<AdminCompanyDTO, CompanyDetail>().ReverseMap();
            CreateMap<AdminCompanyDTO, ApplicationUser>().ReverseMap();
            CreateMap<AdminCompanyResponseDTO, CompanyDetail>().ReverseMap();
            CreateMap<AdminCompanyResponseDTO, ApplicationUser>().ReverseMap();
            CreateMap<AdminProfileRequestDTO, ApplicationUser>().ReverseMap();

            CreateMap<AddProductDTO, Product>().ReverseMap();
            CreateMap<ProductResponselistDTO, Product>().ReverseMap();

            CreateMap<ProductVariantDTO, Product>().ReverseMap();
            CreateMap<ProductVariantDTO, AccessoriesVariants>().ReverseMap();
            CreateMap<ProductVariantDTO, AudioVariants>().ReverseMap();
            CreateMap<ProductVariantDTO, CameraVariants>().ReverseMap();
            CreateMap<ProductVariantDTO, CertificationVariants>().ReverseMap();
            CreateMap<ProductVariantDTO, EnvironmentVariants>().ReverseMap();
            CreateMap<ProductVariantDTO, GeneralVariants>().ReverseMap();
            CreateMap<ProductVariantDTO, InstallationDocumentVariants>().ReverseMap();
            CreateMap<ProductVariantDTO, LensVariants>().ReverseMap();
            CreateMap<ProductVariantDTO, NetworkVariants>().ReverseMap();
            CreateMap<ProductVariantDTO, PowerVariants>().ReverseMap();
            CreateMap<ProductVariantDTO, VideoVariants>().ReverseMap();

            CreateMap<ProductUpdateDTO, Product>().ReverseMap();
            CreateMap<ProductUpdateDTO, AccessoriesVariants>().ReverseMap();
            CreateMap<ProductUpdateDTO, AudioVariants>().ReverseMap();
            CreateMap<ProductUpdateDTO, CameraVariants>().ReverseMap();
            CreateMap<ProductUpdateDTO, CertificationVariants>().ReverseMap();
            CreateMap<ProductUpdateDTO, EnvironmentVariants>().ReverseMap();
            CreateMap<ProductUpdateDTO, GeneralVariants>().ReverseMap();
            CreateMap<ProductUpdateDTO, InstallationDocumentVariants>().ReverseMap();
            CreateMap<ProductUpdateDTO, LensVariants>().ReverseMap();
            CreateMap<ProductUpdateDTO, NetworkVariants>().ReverseMap();
            CreateMap<ProductUpdateDTO, PowerVariants>().ReverseMap();
            CreateMap<ProductUpdateDTO, VideoVariants>().ReverseMap();
            CreateMap<UserManual, UserMannualDTO>().ReverseMap();
            CreateMap<DistributorDetailForDealerDTO, DistributorDetail>().ReverseMap();
            CreateMap<InstallationDocumentVariants, InstallationDocumentDTO>().ReverseMap();
            CreateMap<RewardproductListDTO, RewardProduct>().ReverseMap();
            CreateMap<AddOrUpdateRewardProductDTo, RewardProduct>().ReverseMap();


            CreateMap<CameraVariantsDTO, CameraVariants>().ReverseMap();
            CreateMap<AudioVariantsDTO, AudioVariants>().ReverseMap();
            CreateMap<CertificationVariantsDTO, CertificationVariants>().ReverseMap();
            CreateMap<EnvironmentVariantsDTO, EnvironmentVariants>().ReverseMap();
            CreateMap<GeneralVariantsDTO, GeneralVariants>().ReverseMap();
            CreateMap<LensVariantsDTO, LensVariants>().ReverseMap();
            CreateMap<NetworkVariantsDTO, NetworkVariants>().ReverseMap();
            CreateMap<PowerVariantsDTO, PowerVariants>().ReverseMap();
            CreateMap<VideoVariantsDTO, VideoVariants>().ReverseMap();
            CreateMap<AccessoriesVariantsDTO, AccessoriesVariants>().ReverseMap();

            CreateMap<ProductResponsesDTO, ProductVariantDTO>().ReverseMap();

            CreateMap<ProductResponsesDTO, Product>().ReverseMap();
            CreateMap<ProductResponsesDTO, AccessoriesVariants>().ReverseMap();
            CreateMap<ProductResponsesDTO, AudioVariants>().ReverseMap();
            CreateMap<ProductResponsesDTO, CameraVariants>().ReverseMap();
            CreateMap<ProductResponsesDTO, CertificationVariants>().ReverseMap();
            CreateMap<ProductResponsesDTO, EnvironmentVariants>().ReverseMap();
            CreateMap<ProductResponsesDTO, GeneralVariants>().ReverseMap();
            CreateMap<ProductResponsesDTO, InstallationDocumentVariants>().ReverseMap();
            CreateMap<ProductResponsesDTO, LensVariants>().ReverseMap();
            CreateMap<ProductResponsesDTO, NetworkVariants>().ReverseMap();
            CreateMap<ProductResponsesDTO, PowerVariants>().ReverseMap();
            CreateMap<ProductResponsesDTO, VideoVariants>().ReverseMap();
            CreateMap<UserDetailResponseDTO, UserDetail>().ReverseMap();
            CreateMap<UserDetailResponseDTO, ApplicationUser>().ReverseMap();
            CreateMap<UserDetailRequestDTO, ApplicationUser>().ReverseMap();
            CreateMap<UserProductListFromCart, Product>().ReverseMap();
            CreateMap<UserProductResponsesDTO, Product>().ReverseMap();
            CreateMap<OrderResponseDTO, UserOrder>().ReverseMap();
            CreateMap<DistributorOrderDetailDTO, UserOrder>().ReverseMap();
            CreateMap<DistributorOrderedProductDTO, UserOrderedProduct>().ReverseMap();
            CreateMap<DealerProductResponsesDTO, Product>().ReverseMap();
            CreateMap<PrivacyPolicyViewModel, PrivacyPolicy>().ReverseMap();
            CreateMap<UpdatePrivacyPolicyViewModels, PrivacyPolicy>().ReverseMap();
            CreateMap<TermsAndConditionsViewModel, TermsAndConditions>().ReverseMap();
            CreateMap<PrivacyPolicyAdminViewModels, PrivacyPolicy>().ReverseMap();
            CreateMap<TermsAndConditionsAdminViewModel, TermsAndConditions>().ReverseMap();
            CreateMap<UpdateTermsAndConditionsViewModel, TermsAndConditions>().ReverseMap();
            CreateMap<ContactUsViewModel, ContactUs>().ReverseMap();
            CreateMap<GetContactUsViewModel, ContactUs>().ReverseMap();
            CreateMap<UpdateAboutUsViewModels, AboutUs>().ReverseMap();
            CreateMap<AboutUsAdminViewModels, AboutUs>().ReverseMap();
            CreateMap<AboutUsViewModel, AboutUs>().ReverseMap();
        }
    }
}