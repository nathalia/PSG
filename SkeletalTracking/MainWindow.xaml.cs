﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using Coding4Fun.Kinect.Wpf; 

namespace SkeletalTracking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool closing = false;
        const int skeletonCount = 6; 
        Skeleton[] allSkeletons = new Skeleton[skeletonCount];

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            kinectSensorChooser1.KinectSensorChanged += new DependencyPropertyChangedEventHandler(kinectSensorChooser1_KinectSensorChanged);

        }

        void kinectSensorChooser1_KinectSensorChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            KinectSensor old = (KinectSensor)e.OldValue;

            StopKinect(old);

            KinectSensor sensor = (KinectSensor)e.NewValue;

            if (sensor == null)
            {
                return;
            }

            var parameters = new TransformSmoothParameters
            {
                Smoothing = 0.3f,
                Correction = 0.0f,
                Prediction = 0.0f,
                JitterRadius = 1.0f,
                MaxDeviationRadius = 0.5f
            };
            sensor.SkeletonStream.Enable(parameters);

            sensor.SkeletonStream.Enable();

            sensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(sensor_AllFramesReady);
            sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30); 
            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);

            try
            {
                sensor.Start();
            }
            catch (System.IO.IOException)
            {
                kinectSensorChooser1.AppConflictOccurred();
            }
        }

        void sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            if (closing)
            {
                return;
            }

            //Get a skeleton
            Skeleton first =  GetFirstSkeleton(e);

            if (first == null)
            {
                return; 
            }

            //set scaled position
            ScalePosition(head, first.Joints[JointType.Head]);
            ScalePosition(leftHand, first.Joints[JointType.HandLeft]);
            ScalePosition(rightHand, first.Joints[JointType.HandRight]);
            ScalePosition(rightShoulder, first.Joints[JointType.ShoulderRight]);
            ScalePosition(leftShoulder, first.Joints[JointType.ShoulderLeft]);

            GetCameraPoint(first, e); 

        }

        void GetCameraPoint(Skeleton first, AllFramesReadyEventArgs e)
        {

            using (DepthImageFrame depth = e.OpenDepthImageFrame())
            {
                if (depth == null ||
                    kinectSensorChooser1.Kinect == null)
                {
                    return;
                }
                

                //Map a joint location to a point on the depth map
                //head
                DepthImagePoint headDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.Head].Position);
                //left hand
                DepthImagePoint leftHandDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.HandLeft].Position);
                //right hand
                DepthImagePoint rightHandDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.HandRight].Position);
                //left shoulder
                DepthImagePoint leftShoulderDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.ShoulderLeft].Position);
                //right shoulder
                DepthImagePoint rightShoulderDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.ShoulderRight].Position);
                //left elbow
                DepthImagePoint leftElbowDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.ElbowLeft].Position);
                //right elbow
                DepthImagePoint rightElbowDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.ElbowRight].Position);
                //left trocanter
                DepthImagePoint leftTrocanterDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.HipLeft].Position);
                //right trocanter
                DepthImagePoint rightTrocanterDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.HipRight].Position);
                //left maleolo
                DepthImagePoint leftMaleoloDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.FootLeft].Position);
                //right maleolo
                DepthImagePoint rightMaleoloDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.FootRight].Position);

                //Map a depth point to a point on the color image
                //head
                ColorImagePoint headColorPoint =
                    depth.MapToColorImagePoint(headDepthPoint.X, headDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //left hand
                ColorImagePoint leftHandColorPoint =
                    depth.MapToColorImagePoint(leftHandDepthPoint.X, leftHandDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //right hand
                ColorImagePoint rightHandColorPoint =
                    depth.MapToColorImagePoint(rightHandDepthPoint.X, rightHandDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);

                //left shoulder
                ColorImagePoint leftShoulderColorPoint =
                    depth.MapToColorImagePoint(leftShoulderDepthPoint.X, leftShoulderDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //right shoulder
                ColorImagePoint rightShoulderColorPoint =
                    depth.MapToColorImagePoint(rightShoulderDepthPoint.X, rightShoulderDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);

                //left elbow
                ColorImagePoint leftElbowColorPoint =
                    depth.MapToColorImagePoint(leftElbowDepthPoint.X, leftElbowDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //right elbow
                ColorImagePoint rightElbowColorPoint =
                    depth.MapToColorImagePoint(rightElbowDepthPoint.X, rightElbowDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //left trocanter
                ColorImagePoint leftTrocanterColorPoint =
                    depth.MapToColorImagePoint(leftTrocanterDepthPoint.X, leftTrocanterDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //right trocanter
                ColorImagePoint rightTrocanterColorPoint =
                    depth.MapToColorImagePoint(rightTrocanterDepthPoint.X, rightTrocanterDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //left maleolo
                ColorImagePoint leftMaleoloColorPoint =
                    depth.MapToColorImagePoint(leftMaleoloDepthPoint.X, leftMaleoloDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //right maleolo
                ColorImagePoint rightMaleoloColorPoint =
                    depth.MapToColorImagePoint(rightMaleoloDepthPoint.X, rightMaleoloDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);

                //Set location
                CameraPosition(head, headColorPoint);
                CameraPosition(leftHand, leftHandColorPoint);
                CameraPosition(rightHand, rightHandColorPoint);
                CameraPosition(rightShoulder, rightShoulderColorPoint);
                CameraPosition(leftShoulder, leftShoulderColorPoint);
                CameraPosition(rightElbow, rightElbowColorPoint);
                CameraPosition(leftElbow, leftElbowColorPoint);
                CameraPosition(rightTrocanter, rightTrocanterColorPoint);
                CameraPosition(leftTrocanter, leftTrocanterColorPoint);
                CameraPosition(rightMaleolo, rightMaleoloColorPoint);
                CameraPosition(leftMaleolo, leftMaleoloColorPoint);
            }        
        }


        Skeleton GetFirstSkeleton(AllFramesReadyEventArgs e)
        {
            using (SkeletonFrame skeletonFrameData = e.OpenSkeletonFrame())
            {
                if (skeletonFrameData == null)
                {
                    return null; 
                }

                
                skeletonFrameData.CopySkeletonDataTo(allSkeletons);

                //get the first tracked skeleton
                Skeleton first = (from s in allSkeletons
                                         where s.TrackingState == SkeletonTrackingState.Tracked
                                         select s).FirstOrDefault();

                return first;

            }
        }

        private void StopKinect(KinectSensor sensor)
        {
            if (sensor != null)
            {
                if (sensor.IsRunning)
                {
                    //stop sensor 
                    sensor.Stop();

                    //stop audio if not null
                    if (sensor.AudioSource != null)
                    {
                        sensor.AudioSource.Stop();
                    }


                }
            }
        }

        private void CameraPosition(FrameworkElement element, ColorImagePoint point)
        {
            //Divide by 2 for width and height so point is right in the middle 
            // instead of in top/left corner
            Canvas.SetLeft(element, point.X - element.Width / 2);
            Canvas.SetTop(element, point.Y - element.Height / 2);

        }

        private void ScalePosition(FrameworkElement element, Joint joint)
        {
            //convert the value to X/Y
            //Joint scaledJoint = joint.ScaleTo(1280, 720); 
            
            //convert & scale (.3 = means 1/3 of joint distance)
            Joint scaledJoint = joint.ScaleTo(1280, 720, .3f, .3f);

            Canvas.SetLeft(element, scaledJoint.Position.X);
            Canvas.SetTop(element, scaledJoint.Position.Y); 
            
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            closing = true; 
            StopKinect(kinectSensorChooser1.Kinect); 
        }



    }
}
