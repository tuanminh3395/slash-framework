﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlueprintTest.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Slash.ECS.Tests.Blueprints
{
    using NUnit.Framework;

    using Slash.Collections.AttributeTables;
    using Slash.ECS.Blueprints;
    using Slash.ECS.Components;
    using Slash.Tests.Utils;

    public class BlueprintTest
    {
        #region Constants

        private const string AttributeKey = "AttributeKey";

        private const int AttributeValue = 123;

        private const string ParentId = "ParentBlueprint";

        #endregion

        #region Fields

        private Blueprint blueprint;

        #endregion

        #region Public Methods and Operators

        [SetUp]
        public void SetUp()
        {
            this.blueprint = new Blueprint { ParentId = ParentId };
        }

        [Test]
        public void TestAttributeTableAndComponentTypesSerialization()
        {
            this.blueprint.AttributeTable.Add(AttributeKey, AttributeValue);
            this.blueprint.ComponentTypes.Add(typeof(TestComponent));
            SerializationTestUtils.TestXmlSerialization(this.blueprint);
        }

        [Test]
        public void TestAttributeTableSerialization()
        {
            this.blueprint.AttributeTable.Add(AttributeKey, AttributeValue);
            SerializationTestUtils.TestXmlSerialization(this.blueprint);
        }

        [Test]
        public void TestComponentTypesSerialization()
        {
            this.blueprint.ComponentTypes.Add(typeof(TestComponent));
            SerializationTestUtils.TestXmlSerialization(this.blueprint);
        }

        [Test]
        public void TestCopyConstructorParentId()
        {
            // Try to copy blueprint.
            var newBlueprint = new Blueprint(this.blueprint);

            // Check that parent id was copied.
            Assert.AreEqual(newBlueprint.ParentId, ParentId);
        }

        #endregion
    }

    public class TestComponent : IEntityComponent
    {
        #region Public Methods and Operators

        public void InitComponent(IAttributeTable attributeTable)
        {
        }

        #endregion
    }
}