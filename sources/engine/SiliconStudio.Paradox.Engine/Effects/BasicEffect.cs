// <auto-generated>
// Do not edit this file yourself!
//
// This code was generated by Paradox Shader Mixin Code Generator.
// To generate it yourself, please install SiliconStudio.Paradox.VisualStudio.Package .vsix
// and re-save the associated .pdxfx.
// </auto-generated>

using SiliconStudio.Core;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Paradox.Shaders;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;


#line 1 "C:\Projects\Paradox\sources\engine\SiliconStudio.Paradox.Engine\Effects\BasicEffect.pdxfx"
using SiliconStudio.Paradox.Effects.Data;

#line 2
using SiliconStudio.Paradox.Shaders.Compiler;

#line 4
namespace ParadoxEffects
{

    #line 6
    public partial class WithSkinning  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 11
            context.CloneProperties();

            #line 11
            mixin.Mixin.CloneFrom(mixin.Parent.Mixin);

            #line 12
            if (context.GetParam(MaterialParameters.HasSkinningPosition))
            {

                #line 14
                if (context.GetParam(MaterialParameters.SkinningBones) > context.GetParam(MaterialParameters.SkinningMaxBones))
                {

                    #line 17
                    context.SetParam(MaterialParameters.SkinningMaxBones, context.GetParam(MaterialParameters.SkinningBones));
                }

                #line 19
                mixin.Mixin.AddMacro("SkinningMaxBones", context.GetParam(MaterialParameters.SkinningMaxBones));

                #line 20
                context.Mixin(mixin, "TransformationSkinning");

                #line 22
                if (context.GetParam(MaterialParameters.HasSkinningNormal))

                    #line 23
                    context.Mixin(mixin, "NormalSkinning");

                #line 25
                if (context.GetParam(MaterialParameters.HasSkinningTangent))

                    #line 26
                    context.Mixin(mixin, "TangentSkinning");
            }
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("WithSkinning", new WithSkinning());
        }
    }

    #line 30
    public partial class BasicEffect  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 37
            context.Mixin(mixin, "ShaderBase");

            #line 38
            context.Mixin(mixin, "TransformationWAndVP");

            #line 39
            context.Mixin(mixin, "NormalVSStream");

            #line 40
            context.Mixin(mixin, "PositionVSStream");

            #line 41
            context.Mixin(mixin, "BRDFDiffuseBase");

            #line 42
            context.Mixin(mixin, "BRDFSpecularBase");

            #line 43
            context.Mixin(mixin, "LightMultiDirectionalShadingPerPixel", 2);

            #line 44
            context.Mixin(mixin, "TransparentShading");

            #line 45
            context.Mixin(mixin, "DiscardTransparent");

            #line 47
            if (context.GetParam(MaterialParameters.AlbedoDiffuse) != null)
            {

                {

                    #line 49
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                    #line 49
                    context.Mixin(__subMixin, "ComputeBRDFDiffuseLambert");
                    mixin.Mixin.AddComposition("DiffuseLighting", __subMixin.Mixin);
                }

                {

                    #line 50
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                    #line 50
                    context.Mixin(__subMixin, context.GetParam(MaterialParameters.AlbedoDiffuse));
                    mixin.Mixin.AddComposition("albedoDiffuse", __subMixin.Mixin);
                }
            }

            #line 53
            if (context.GetParam(MaterialParameters.AlbedoSpecular) != null)
            {

                {

                    #line 55
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                    #line 55
                    context.Mixin(__subMixin, "ComputeBRDFColorSpecularBlinnPhong");
                    mixin.Mixin.AddComposition("SpecularLighting", __subMixin.Mixin);
                }

                {

                    #line 56
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                    #line 56
                    context.Mixin(__subMixin, context.GetParam(MaterialParameters.AlbedoSpecular));
                    mixin.Mixin.AddComposition("albedoSpecular", __subMixin.Mixin);
                }

                #line 58
                if (context.GetParam(MaterialParameters.SpecularPowerMap) != null)
                {

                    #line 60
                    context.Mixin(mixin, "SpecularPower");

                    {

                        #line 61
                        var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                        #line 61
                        context.Mixin(__subMixin, context.GetParam(MaterialParameters.SpecularPowerMap));
                        mixin.Mixin.AddComposition("SpecularPowerMap", __subMixin.Mixin);
                    }
                }

                #line 64
                if (context.GetParam(MaterialParameters.SpecularIntensityMap) != null)
                {

                    {

                        #line 66
                        var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                        #line 66
                        context.Mixin(__subMixin, context.GetParam(MaterialParameters.SpecularIntensityMap));
                        mixin.Mixin.AddComposition("SpecularIntensityMap", __subMixin.Mixin);
                    }
                }
            }

            {

                #line 70
                var __subMixin = new ShaderMixinSourceTree() { Name = "WithSkinning", Parent = mixin };
                mixin.Children.Add(__subMixin);

                #line 70
                context.BeginChild(__subMixin);

                #line 70
                context.Mixin(__subMixin, "WithSkinning");

                #line 70
                context.EndChild();
            }
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("BasicEffect", new BasicEffect());
        }
    }
}