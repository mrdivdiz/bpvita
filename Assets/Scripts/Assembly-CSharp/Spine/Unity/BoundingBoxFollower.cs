using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity
{
	[ExecuteInEditMode]
	public class BoundingBoxFollower : MonoBehaviour
	{
		public Slot Slot
		{
			get
			{
				return this.slot;
			}
		}

		public BoundingBoxAttachment CurrentAttachment
		{
			get
			{
				return this.currentAttachment;
			}
		}

		public string CurrentAttachmentName
		{
			get
			{
				return this.currentAttachmentName;
			}
		}

		public PolygonCollider2D CurrentCollider
		{
			get
			{
				return this.currentCollider;
			}
		}

		public bool IsTrigger
		{
			get
			{
				return this.isTrigger;
			}
		}

		private void OnEnable()
		{
			this.ClearColliders();
			if (this.skeletonRenderer == null)
			{
				this.skeletonRenderer = base.GetComponentInParent<SkeletonRenderer>();
			}
			if (this.skeletonRenderer != null)
			{
				SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
				skeletonRenderer.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Remove(skeletonRenderer.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.HandleRebuild));
				SkeletonRenderer skeletonRenderer2 = this.skeletonRenderer;
				skeletonRenderer2.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Combine(skeletonRenderer2.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.HandleRebuild));
				if (this.hasReset)
				{
					this.HandleRebuild(this.skeletonRenderer);
				}
			}
		}

		private void OnDisable()
		{
			SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
			skeletonRenderer.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Remove(skeletonRenderer.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.HandleRebuild));
		}

		private void Start()
		{
			if (!this.hasReset && this.skeletonRenderer != null)
			{
				this.HandleRebuild(this.skeletonRenderer);
			}
		}

		public void HandleRebuild(SkeletonRenderer renderer)
		{
			if (string.IsNullOrEmpty(this.slotName))
			{
				return;
			}
			this.hasReset = true;
			this.ClearColliders();
			this.colliderTable.Clear();
			if (this.skeletonRenderer.skeleton == null)
			{
				SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
				skeletonRenderer.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Remove(skeletonRenderer.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.HandleRebuild));
				this.skeletonRenderer.Initialize(false);
				SkeletonRenderer skeletonRenderer2 = this.skeletonRenderer;
				skeletonRenderer2.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Combine(skeletonRenderer2.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.HandleRebuild));
			}
			Skeleton skeleton = this.skeletonRenderer.skeleton;
			this.slot = skeleton.FindSlot(this.slotName);
			int slotIndex = skeleton.FindSlotIndex(this.slotName);
			if (base.gameObject.activeInHierarchy)
			{
				foreach (Skin skin in skeleton.Data.Skins)
				{
					List<string> list = new List<string>();
					skin.FindNamesForSlot(slotIndex, list);
					foreach (string text in list)
					{
						Attachment attachment = skin.GetAttachment(slotIndex, text);
						BoundingBoxAttachment boundingBoxAttachment = attachment as BoundingBoxAttachment;
						if (boundingBoxAttachment != null)
						{
							PolygonCollider2D polygonCollider2D = SkeletonUtility.AddBoundingBoxAsComponent(boundingBoxAttachment, base.gameObject, true);
							polygonCollider2D.enabled = false;
							polygonCollider2D.hideFlags = HideFlags.NotEditable;
							polygonCollider2D.isTrigger = this.IsTrigger;
							this.colliderTable.Add(boundingBoxAttachment, polygonCollider2D);
							this.attachmentNameTable.Add(boundingBoxAttachment, text);
						}
					}
				}
			}
		}

		private void ClearColliders()
		{
			PolygonCollider2D[] components = base.GetComponents<PolygonCollider2D>();
			if (components.Length == 0)
			{
				return;
			}
			foreach (PolygonCollider2D polygonCollider2D in components)
			{
				if (polygonCollider2D != null)
				{
					UnityEngine.Object.Destroy(polygonCollider2D);
				}
			}
			this.colliderTable.Clear();
			this.attachmentNameTable.Clear();
		}

		private void LateUpdate()
		{
			if (!this.skeletonRenderer.valid)
			{
				return;
			}
			if (this.slot != null && this.slot.Attachment != this.currentAttachment)
			{
				this.MatchAttachment(this.slot.Attachment);
			}
		}

		private void MatchAttachment(Attachment attachment)
		{
			BoundingBoxAttachment boundingBoxAttachment = attachment as BoundingBoxAttachment;
			if (this.currentCollider != null)
			{
				this.currentCollider.enabled = false;
			}
			if (boundingBoxAttachment == null)
			{
				this.currentCollider = null;
			}
			else
			{
				this.currentCollider = this.colliderTable[boundingBoxAttachment];
				this.currentCollider.enabled = true;
			}
			this.currentAttachment = boundingBoxAttachment;
			this.currentAttachmentName = ((this.currentAttachment != null) ? this.attachmentNameTable[boundingBoxAttachment] : null);
		}

		public SkeletonRenderer skeletonRenderer;

		[SpineSlot("", "skeletonRenderer", true)]
		public string slotName;

		public bool isTrigger;

		private Slot slot;

		private BoundingBoxAttachment currentAttachment;

		private string currentAttachmentName;

		private PolygonCollider2D currentCollider;

		private bool valid;

		private bool hasReset;

		public readonly Dictionary<BoundingBoxAttachment, PolygonCollider2D> colliderTable = new Dictionary<BoundingBoxAttachment, PolygonCollider2D>();

		public readonly Dictionary<BoundingBoxAttachment, string> attachmentNameTable = new Dictionary<BoundingBoxAttachment, string>();
	}
}
