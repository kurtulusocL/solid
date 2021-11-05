# solid
a solid project with .net core

WebUI => startup.cs => add this for fluent valdation ===>

services.AddControllersWithViews().AddRazorRuntimeCompilation().AddFluentValidation(i=>i.RegisterValidatorsFromAssemblyContaining<AboutValidation>);
services.AddControllersWithViews().AddFluentValidation(i=>i.RegisterValidatorsFromAssemblyContaining<AboutValidation>);
services.AddControllersWithViews().AddFluentValidation(i=>i.RegisterValidatorsFromAssemblyContaining<CategoryValidation>);
services.AddControllersWithViews().AddFluentValidation(i=>i.RegisterValidatorsFromAssemblyContaining<CommentValidation>);
services.AddControllersWithViews().AddFluentValidation(i=>i.RegisterValidatorsFromAssemblyContaining<PictureValidation>);
services.AddControllersWithViews().AddFluentValidation(i=>i.RegisterValidatorsFromAssemblyContaining<ProductValidation>);
services.AddControllersWithViews().AddFluentValidation(i=>i.RegisterValidatorsFromAssemblyContaining<ProductDetailValidation>);
