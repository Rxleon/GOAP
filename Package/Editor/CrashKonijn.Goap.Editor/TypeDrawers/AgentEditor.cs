﻿using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Editor.Drawers;
using CrashKonijn.Goap.Editor.Elements;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CrashKonijn.Goap.Editor.TypeDrawers
{
    [CustomEditor(typeof(AgentBehaviour))]
    public class AgentEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            
            root.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>($"{GoapEditorSettings.BasePath}/Styles/Generic.uss"));
            
            root.Add(new PropertyField(this.serializedObject.FindProperty("goapSetBehaviour")));
            
            if (!Application.isPlaying)
                return root;
            
            var agent = (AgentBehaviour) this.target;
            
            root.Add(new Card((card) =>
            {
                card.schedule.Execute(() =>
                {
                    card.Clear();
                    card.Add(new Label("Goal: " + agent.CurrentGoal?.GetType().Name));
                    card.Add(new Label("Action: " + agent.CurrentAction?.GetType().Name));
                }).Every(33);
            }));
            
            root.Add(new Card((card) =>
            {
                card.schedule.Execute(() =>
                {
                    card.Clear();
                    card.Add(new ObjectDrawer(agent.CurrentActionData));
                }).Every(33);
            }));


            return root;
        }
    }
}