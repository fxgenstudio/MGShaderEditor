using Microsoft.Xna.Framework;

namespace MGShaderEditor
{
  public class Camera
  {
    #region -- Fields --
    protected static Camera activeCamera = null;
    protected static Camera gameCamera = null;

    protected Game m_game;

    // View and projection
    protected Matrix m_projection = Matrix.Identity;
    protected Matrix m_view = Matrix.Identity;
    protected Vector3 m_position = new Vector3(0, 0, 1000);
    protected Vector3 m_angleRad = new Vector3();

    #endregion

    #region -- Properties --
    public static Camera ActiveCamera
    {
      get { return activeCamera; }
      set { activeCamera = value; }
    }

    public Matrix Projection
    {
      get { return m_projection; }
      set { m_projection = value; }
    }

    public Matrix View
    {
      get { return m_view; }
    }

    public Vector3 Position
    {
      get { return m_position; }
      set { m_position = value; }
    }


    public Vector3 AngleDeg  //Degree
    {
      get { return new Vector3(MathHelper.ToDegrees(m_angleRad.X), MathHelper.ToDegrees(m_angleRad.Y), MathHelper.ToDegrees(m_angleRad.Z)); }
      set { m_angleRad.X = MathHelper.ToRadians(value.X); m_angleRad.Y = MathHelper.ToRadians(value.Y); m_angleRad.Z = MathHelper.ToRadians(value.Z); }
    }

    public Vector3 AngleRad  //Radian
    {
      get { return m_angleRad; }
      set { m_angleRad = value; }
    }

    public float Ratio
    {
      get;
      protected set;
    }

    public float FOV  //In degree
    {
      get;
      set;
    }

    public float OrthoWidth { get; set; }
    public float OrthoHeight { get; set; }

    #endregion

    public Camera(Game _game)
    {
      m_game = _game;

      FOV = 100;//In degree

      if (ActiveCamera == null)
        ActiveCamera = this;
    }

    virtual public void Update(float _dt)
    {
      Ratio = m_game.GraphicsDevice.Viewport.AspectRatio;

      if (OrthoWidth != 0 && OrthoHeight != 0)
      {
        m_projection = Matrix.CreateOrthographic(OrthoWidth, OrthoHeight, 1.0f, 500.0f);
      }
      else
      {
        m_projection = Matrix.CreatePerspectiveFieldOfView((FOV / 2.0f) * MathHelper.Pi / 180.0f, Ratio, 1.0f, 500.0f); //1.74
      }

      ///////////////////////////////
      // Update Matrix

      m_view.M11 = 1.00000000f;
      m_view.M12 = 0.00000000f;
      m_view.M13 = 0.00000000f;
      m_view.M14 = 0.00000000f;

      m_view.M21 = 0.00000000f;
      m_view.M22 = 1.00000000f;
      m_view.M23 = 0.00000000f;
      m_view.M24 = 0.00000000f;

      m_view.M31 = 0.00000000f;
      m_view.M32 = 0.00000000f;
      m_view.M33 = 1.00000000f;
      m_view.M44 = 0.00000000f;

      m_view.M41 = 0.00000000f;
      m_view.M42 = 0.00000000f;
      m_view.M43 = 0.00000000f;
      m_view.M44 = 1.00000000f;

      m_view *= Matrix.CreateTranslation(-m_position);
      m_view *= Matrix.CreateRotationZ(m_angleRad.Z); //Roll
      m_view *= Matrix.CreateRotationY(m_angleRad.Y); //yaw
      m_view *= Matrix.CreateRotationX(m_angleRad.X); //Pitch

    }

  }

  /// <summary>
  /// Orbit Camera for editing...
  /// </summary>
  public class OrbitCamera : Camera
  {
    Vector3 m_targetPos;
    public Vector3 TargetPosition
    {
      get { return m_targetPos; }
      set { m_targetPos = value; }
    }

    public float TargetDistance { get; set; }


    public OrbitCamera(Game _game)
      : base(_game)
    {
      TargetDistance = 2;
    }

    public override void Update(float _dt)
    {
      Matrix rotPitch = Matrix.CreateRotationX(m_angleRad.X); //Pitch
      Matrix rotYaw = Matrix.CreateRotationY(m_angleRad.Y); //yaw
      Vector3 v = Vector3.Backward * TargetDistance;
      v = Vector3.Transform(v, rotPitch);
      v = Vector3.Transform(v, rotYaw);

      Position = TargetPosition + v;

      //Init Matrices
      Ratio = m_game.GraphicsDevice.Viewport.AspectRatio;
      float fFOV = 100.0f;  //In degree

      m_projection = Matrix.CreatePerspectiveFieldOfView((fFOV / 2.0f) * MathHelper.Pi / 180.0f, Ratio, 0.1f, 500.0f);
      m_view = Matrix.CreateLookAt(Position, TargetPosition, Vector3.Up);

    }

  }
}