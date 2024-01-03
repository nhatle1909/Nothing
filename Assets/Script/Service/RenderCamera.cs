//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace Assets.Script.Service
//{
//    public class RenderCamera : MonoBehaviour
//    {

//        // Use this for initialization
//        public Camera camera;
//        void Start()
//        {
//            camera = Camera.main;
//        }

//        // Called for each renderer that became visible
//        void OnBecameVisible()
//        {
//            // Add the renderer to a list of visible objects
//            List<Renderer> visibleRenderers = new List<Renderer>();
//            visibleRenderers.Add(renderer);

//            // Set the camera's culling mask to only render these objects
//            camera.cullingMask = 1 << LayerMask.NameToLayer("Visible"); // Assuming objects are on a layer named "Visible"
//        }

//    }
//}