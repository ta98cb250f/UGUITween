﻿/// <summary>
/// スケールのTween
///
/// @author t-yoshino
/// @date 2020/06/28
/// @file TweenScale.cs
/// </summary>
using UnityEngine;

/// <summary>
/// スケールのTween
/// </summary>
public class TweenScale : TweenBase {

	//! ターゲットにするRectTransform
	RectTransform _rect_transform = null;
	//! ターゲットにするTransform
	Transform _transform = null;

	//! 最初の位置
	[SerializeField]
	Vector3 _from = new Vector3();
	//! 最後の位置
	[SerializeField]
	Vector3 _to = new Vector3();

	/// <summary>
	/// 値の更新
	/// </summary>
	/// <param name="v">カーブからサンプリングした0−1で正規化された値</param>
	protected override void _UpdateValue( float v ) {

		if( !_rect_transform && !_transform ) {
			_rect_transform = GetComponent<RectTransform>();
			_transform = GetComponent<Transform>();
		}

		Vector3 value = _from * ( 1.0f - v ) + _to * v;
		if( _rect_transform ) {
			_rect_transform.localScale = new Vector2( value.x, value.y );
		} else if( _transform ) {
			_transform.localScale = value;
		} else {
			enabled = false;
		}
	}
}
