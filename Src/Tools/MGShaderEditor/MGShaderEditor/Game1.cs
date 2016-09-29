//////////////////////////////////////////////////////////////////////////
// Notes:
//    - Camera Zoom => Control key + Vertical Mouse Dragging
//    - Camera Rotation => Horizontal or Vertical Mouse Dragging
//
//////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Primitives3D;
using System.Collections.Generic;
using System.Diagnostics;

namespace MGShaderEditor
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        #region -- Fields --
        GraphicsDeviceManager m_graphics;
        SpriteBatch m_spriteBatch;
        Effect m_curEffect;
        float m_fmodelRotation;

        OrbitCamera m_camera;

        Matrix m_World;

        MouseState m_prevMouseState;
        private bool m_bDraggingCamera;
        private int m_nStartDragX;
        private int m_nStartDragY;
        private bool m_bZoomingCamera;

        Texture2D[] m_texSlots = new Texture2D[TextureSlotsUserControl.SlotsCount];

        #endregion

        #region -- Properties --
        public GeometricPrimitive CurPrimitive { get; set; }
        public List<UIbaseParam> Parameters { get; set; }
        #endregion

        public Game1()
        {
            m_graphics = new GraphicsDeviceManager(this);
            m_graphics.PreferredBackBufferWidth = 320;
            m_graphics.PreferredBackBufferHeight = 200;

            Parameters = new List<UIbaseParam>();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Create Effect from 2MGFX bytes code
        /// </summary>
        public void SetEffectBytesCode(byte[] _byCode)
        {
            m_curEffect = new Effect(m_graphics.GraphicsDevice, _byCode);
        }

        /// <summary>
        /// Set Texture for a Slot
        /// </summary>
        public void SetTextureSlot(int _nSlotIdx, Texture2D _tex)
        {
            if (_nSlotIdx < 0 || _nSlotIdx >= TextureSlotsUserControl.SlotsCount)
                return;

            m_texSlots[_nSlotIdx] = _tex;
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            m_spriteBatch = new SpriteBatch(GraphicsDevice);

            m_camera = new OrbitCamera(this);
            m_camera.Update(0);

            m_World = Matrix.Identity;

            CurPrimitive = null;


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            //Inputs
            var ms = Mouse.GetState();
            var ks = Keyboard.GetState();

            //Control Mouse pos under Game Window
            bool bUnderWindows = false;

            if (Window.ClientBounds.Contains(ms.Position))
                bUnderWindows = true;

            //Process mouse events
            if (bUnderWindows)
            {

                //LMouse Down
                if (ms.LeftButton == ButtonState.Pressed && m_prevMouseState.LeftButton == ButtonState.Released)
                {

                    m_nStartDragX = ms.X;
                    m_nStartDragY = ms.Y;

                    if (ks.IsKeyDown(Keys.LeftControl) == true)
                    {
                        m_bZoomingCamera = true;
                    }
                    else
                    {
                        m_bDraggingCamera = true;
                    }
                }

                //LMouse Up
                if (ms.LeftButton == ButtonState.Released && m_prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    m_bDraggingCamera = false;
                    m_bZoomingCamera = false;
                }

                //Mouse Move and camera dragging
                if (m_bDraggingCamera == true)
                {
                    float turnSpeed = 8f;

                    float offsetX = ((ms.X - m_nStartDragX) * turnSpeed * 0.001f); // pitch degree
                    float offsetY = ((ms.Y - m_nStartDragY) * turnSpeed * 0.001f); // yaw degree

                    var a = m_camera.AngleRad;
                    a.X -= offsetY;
                    a.Y -= offsetX;

                    a.Y = MathHelper.Clamp(a.Y, 0, MathHelper.Pi * 2);
                    a.X = MathHelper.Clamp(a.X, -(MathHelper.PiOver2 - 0.1f), (MathHelper.PiOver2 - 0.1f));

                    m_camera.AngleRad = a;

                    m_nStartDragX = ms.X;
                    m_nStartDragY = ms.Y;
                }

                //Mouse Move and camera zooming 
                if (m_bZoomingCamera == true)
                {
                    float speed = 8f;
                    float offsetY = ((ms.Y - m_nStartDragY) * speed * 0.001f);

                    m_camera.TargetDistance += offsetY;
                    m_camera.TargetDistance = MathHelper.Clamp(m_camera.TargetDistance, 1.0f, 10);

                    m_nStartDragY = ms.Y;
                }

                //Mouse Wheel
                var wheelDelta = m_prevMouseState.ScrollWheelValue - ms.ScrollWheelValue;
                if (wheelDelta != 0)
                {
                    m_camera.TargetDistance += (wheelDelta / 100.0f);
                    m_camera.TargetDistance = MathHelper.Clamp(m_camera.TargetDistance, 1.0f, 10);
                }

                m_prevMouseState = ms;
            }

            //Update Camera Matrices
            m_camera.Update(0);

            //Update Model World Matrice
            if (m_bDraggingCamera == false)
                m_fmodelRotation += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;

            m_World = Matrix.CreateRotationX(m_fmodelRotation) * Matrix.CreateRotationY(m_fmodelRotation) * Matrix.CreateRotationZ(m_fmodelRotation);


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (m_curEffect != null)
            {

                //Set Matrices
                var p1 = m_curEffect.Parameters["xWorld"];
                if (p1 != null)
                    p1.SetValue(m_World);

                var p2 = m_curEffect.Parameters["xView"];
                if (p2 != null)
                    p2.SetValue(m_camera.View);

                var p3 = m_curEffect.Parameters["xProjection"];
                if (p3 != null)
                    p3.SetValue(m_camera.Projection);


                //Set textures
                //for (int i = 0; i < m_texSlots.Length; i++)
                //{
                //    if (m_texSlots[i] != null)
                //    {
                //        var p4 = m_curEffect.Parameters[string.Format("xTexSlot{0}", i)];
                //        if (p4 != null)
                //            p4.SetValue(m_texSlots[i]);
                //    }
                //}

                //UI Parameters
                foreach (var p in Parameters)
                {
                    var px = m_curEffect.Parameters[p.Name];

                    //UIFloatParam
                    if (px!=null && px.ParameterType==EffectParameterType.Single && p is UIFloatParam)
                    {
                        var floatParam = p as UIFloatParam;
                        px.SetValue(floatParam.Value);
                    }
                    //UITexture2DParam
                    else if (px != null && px.ParameterType == EffectParameterType.Texture2D && p is UITexture2DParam)
                    {
                        var texParam = p as UITexture2DParam;
                        Texture2D tex = null;
                        int idx = 0;
                        if (int.TryParse(texParam.Value, out idx))
                        {
                            if (idx >= 0 && idx < m_texSlots.Length && m_texSlots[idx]!=null)
                            {
                                tex = m_texSlots[idx];
                            }
                        }
                        px.SetValue(tex);

                    }

                }


                //Set pass0
                m_curEffect.CurrentTechnique.Passes[0].Apply();

                //Draw
                CurPrimitive.Draw(m_curEffect);

            }

            base.Draw(gameTime);
        }


    }
}
