using Silk.NET.GLFW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Vulkan;

namespace VkTriangleSample
{
    public unsafe class TriangleSample
    {
        //Vulkan/Glfw data
        private Glfw glfw;
        private WindowHandle* windowImpl;
        private VkInstance instance;

        //Custom Data
        private const int Width = 800;
        private const int Height = 600;
        private string Title = "LearnVulkan";

        public void Run()
        {
            InitWindow();
            InitVulkan();
            MainLoop();
            CleanUp();
        }

        private void InitWindow()
        {
            glfw = Glfw.GetApi();

            glfw.Init();
            glfw.WindowHint(WindowHintClientApi.ClientApi, ClientApi.NoApi);
            glfw.WindowHint(WindowHintBool.Resizable, false);

            windowImpl = glfw.CreateWindow(Width, Height, Title, (Monitor*)IntPtr.Zero.ToPointer(), null);
        }

        private void InitVulkan()
        {
            CreateInstance();
        }

        private void CreateInstance()
        {
            VkApplicationInfo appInfo = new();
            appInfo.sType = VkStructureType.ApplicationInfo;
            appInfo.pApplicationName = Title.ToVk();
        }

        private void MainLoop()
        {
            while (!glfw.WindowShouldClose(windowImpl))
            {
                glfw.PollEvents();
            }
        }

        private void CleanUp()
        {
            glfw.DestroyWindow(windowImpl);
            glfw.Terminate();
        }
    }
}
