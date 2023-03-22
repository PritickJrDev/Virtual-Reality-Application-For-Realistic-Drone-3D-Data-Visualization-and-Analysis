using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LineChanger : MonoBehaviour
{
    public XRRayInteractor xri;
    public void Straigt()
    {
        xri.lineType = XRRayInteractor.LineType.StraightLine;
    }

    public void Curve()
    {
        xri.lineType = XRRayInteractor.LineType.ProjectileCurve;
        xri.velocity = 50;
    }
}
